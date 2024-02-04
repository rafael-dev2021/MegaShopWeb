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
    public async Task CreateOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        using var transaction = _appDbContext.Database.BeginTransaction();
        try
        {
            order.WhenConfirmedOrder();
            order.PaymentMethod.DefaultPayment(ePaymentMethod);

            if (order.PaymentMethod.PaymentMethodObjectValue.PaymentStatusObjectValue.EPaymentStatus != EPaymentStatus.Approved)
            {
                // Se o pagamento foi recusado, não salva o pedido
                transaction.Rollback();
                return;
            }

            _appDbContext.Add(order);
            await _appDbContext.SaveChangesAsync();  // Salva o pedido principal

            var cartItems = await _shoppingCartItemRepository.GetShoppingCartItemsAsync();

            foreach (var cartItem in cartItems)
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
                    transaction.Rollback();
                    throw new Exception("Product stock not available.");
                }
            }

            // Salva os detalhes do pedido apenas uma vez após o loop
            await _appDbContext.SaveChangesAsync();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("There was an error processing the request.", ex);
        }
    }

    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _appDbContext.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _appDbContext.Orders
             .AsNoTracking()
             .Include(x => x.OrderDetails)
             .Include(x => x.PaymentMethod)
             .OrderBy(x => x.Id)
             .ToListAsync();
    }

    public async Task<IEnumerable<OrderDetail>> GetOrdersDetailsAsync()
    {
        return await _appDbContext.OrderDetails
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Order)
            .OrderBy(x => x.Id)
            .ToListAsync();
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


