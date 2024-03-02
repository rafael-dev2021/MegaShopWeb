using Domain.Entities.Cart;
using Domain.Entities.Cart.Interfaces;
using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories.Helpers;

public class OrderRepositoryHelper(AppDbContext appDbContext, IShoppingCartItemRepository shoppingCartItemRepository)
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository = shoppingCartItemRepository;

    public async Task<IEnumerable<Order>> FindOrdersByDateAsync(
        DateTime? minDate,
        DateTime? maxDate,
        Expression<Func<Order, DateTime>> datePropertySelector)
    {
        return await _appDbContext.Orders
        .AsNoTracking()
        .Include(o => o.OrderDetails)
        .ThenInclude(p => p.Product)
        .Include(x => x.UserDelivery)
        .Include(x => x.DeliveryAddress)
        .Where(x => !minDate.HasValue ||
            EF.Property<DateTime>(x, datePropertySelector
            .GetPropertyAccess().Name).Date >= minDate.Value.Date)
        .Where(x => !maxDate.HasValue ||
            EF.Property<DateTime>(x, datePropertySelector
            .GetPropertyAccess().Name).Date <= maxDate.Value.Date)
        .OrderByDescending(datePropertySelector)
        .ToListAsync();
    }


    public void ConfirmOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        order.WhenConfirmedOrder();
        order.PaymentMethod.DefaultPayment(ePaymentMethod);

        if (order.PaymentMethod.PaymentMethodObjectValue.PaymentStatusObjectValue.EPaymentStatus != EPaymentStatus.Approved)
        {
            throw new Exception("Payment was declined.");
        }
    }
    public async Task SaveMainOrder(Order order)
    {
        _appDbContext.Add(order);
        await _appDbContext.SaveChangesAsync();
    }
    public async Task ProcessShoppingCartItems(Order order)
    {
        var cartItems = await _shoppingCartItemRepository.GetShoppingCartItemsAsync();

        foreach (var cartItem in cartItems)
        {
            await ProcessCartItem(order, cartItem);
        }
    }
    public async Task ProcessCartItem(Order order, ShoppingCartItem cartItem)
    {
        var product = await _appDbContext.Products.FindAsync(cartItem.Product.Id);

        if (product.Stock >= cartItem.Quantity)
        {
            product.SetStock(product.Stock - cartItem.Quantity);
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
}
