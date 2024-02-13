using Domain.Entities.Cart;
using Domain.Entities.Cart.Interfaces;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Interfaces;
using Domain.Entities.Payments.Enums;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories;

public class OrderRepository(AppDbContext appDbContext, IShoppingCartItemRepository shoppingCartItemRepository) : IOrderRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository = shoppingCartItemRepository;

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _appDbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .Include(x => x.DeliveryAddress)
            .Include(x => x.UserDelivery)
            .Include(x => x.PaymentMethod)
            .Include(x => x.PaymentMethod.CreditCard)
            .Include(x => x.PaymentMethod.DebitCard)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
    public IQueryable<Order> GetPagingListOrders(string filter)
    {
        var result = _appDbContext.Orders
            .AsNoTracking()
            .Include(x => x.DeliveryAddress)
            .Include(x => x.UserDelivery)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            result = result.Where(x =>
                x.UserDelivery.FirstName.Contains(filter)
            );
        }

        return result.OrderBy(x => x.UserDelivery.FirstName);
    }


    public async Task<IEnumerable<OrderDetail>> GetOrdersDetailsAsync()
    {
        return await _appDbContext.OrderDetails
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Order)
                .ThenInclude(order => order.UserDelivery)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _appDbContext.Orders
            .Include(x => x.OrderDetails)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    private void ConfirmOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        order.WhenConfirmedOrder();
        order.PaymentMethod.DefaultPayment(ePaymentMethod);

        if (order.PaymentMethod.PaymentMethodObjectValue.PaymentStatusObjectValue.EPaymentStatus != EPaymentStatus.Approved)
        {
            throw new Exception("Payment was declined.");
        }
    }
    private async Task SaveMainOrder(Order order)
    {
        _appDbContext.Add(order);
        await _appDbContext.SaveChangesAsync();
    }
    private async Task ProcessShoppingCartItems(Order order)
    {
        var cartItems = await _shoppingCartItemRepository.GetShoppingCartItemsAsync();

        foreach (var cartItem in cartItems)
        {
            await ProcessCartItem(order, cartItem);
        }
    }
    private async Task ProcessCartItem(Order order, ShoppingCartItem cartItem)
    {
        var product = await _appDbContext.Products.FindAsync(cartItem.Product.Id);

        if (product.Stock >= cartItem.Quantity)
        {
            product.Stock -= cartItem.Quantity;

            var orderDetails = new OrderDetail
            (
                cartItem.Quantity,
                cartItem.Product.ProductPriceObjectValue.Price,
                order.Id,
                cartItem.Product.Id,
                order.PaymentMethod.Id
            );

            _appDbContext.OrderDetails.Add(orderDetails);
        }
        else
        {
            throw new Exception("Product stock not available.");
        }
    }
    public async Task CreateOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        using var transaction = _appDbContext.Database.BeginTransaction();

        try
        {
            ConfirmOrder(order, ePaymentMethod);

            await SaveMainOrder(order);

            await ProcessShoppingCartItems(order);

            await _appDbContext.SaveChangesAsync();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("There was an error processing the request.", ex);
        }
    }
    public async Task<Order> RemoveOrder(Order order)
    {
        _appDbContext.Remove(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        _appDbContext.Update(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }


}


