using Domain.Entities.Cart.Interfaces;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Interfaces;
using Domain.Entities.Payments.Enums;
using Infra_Data.Context;
using Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories;

public class OrderRepository(
    AppDbContext appDbContext, 
    IShoppingCartItemRepository shoppingCartItemRepository) : IOrderRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    public OrderRepositoryHelper orderRepositoryHelper = new(appDbContext, shoppingCartItemRepository);

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

        return result.OrderBy(x => x.Id);
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


    public async Task<IEnumerable<Order>> FindByOrderConfirmDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        return await orderRepositoryHelper.FindOrdersByDateAsync(minDate, maxDate, x => x.ConfirmedOrder);
    }

    public async Task<IEnumerable<Order>> FindByOrderDispatchedDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        return await orderRepositoryHelper.FindOrdersByDateAsync(minDate, maxDate, x => x.DispatchedOrder);
    }

    public async Task<IEnumerable<Order>> FindByOrderRequestReceivedDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        return await orderRepositoryHelper.FindOrdersByDateAsync(minDate, maxDate, x => x.RequestReceived);
    }


    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _appDbContext.Orders
            .Include(x => x.OrderDetails)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateOrder(Order order, EPaymentMethod ePaymentMethod)
    {
        using var transaction = _appDbContext.Database.BeginTransaction();

        try
        {
            orderRepositoryHelper.ConfirmOrder(order, ePaymentMethod);

            await orderRepositoryHelper.SaveMainOrder(order);

            await orderRepositoryHelper.ProcessShoppingCartItems(order);

            await _appDbContext.SaveChangesAsync();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("There was an error processing the request.", ex);
        }
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        var existingOrder = await _appDbContext.Orders.FindAsync(order.Id);

        if (existingOrder != null)
        {
            existingOrder
                .Update(order.DispatchedOrder, order.RequestReceived);

            existingOrder.DeliveryAddress
                .Update(order.DeliveryAddress.Address,
                        order.DeliveryAddress.Complement,
                        order.DeliveryAddress.ZipCode,
                        order.DeliveryAddress.State,
                        order.DeliveryAddress.City,
                        order.DeliveryAddress.Neighborhood);

            existingOrder.UserDelivery
                .Update(order.UserDelivery.Phone, order.UserDelivery.SSN);

            await _appDbContext.SaveChangesAsync();
        }
        return existingOrder;
    }

    public async Task<Order> RemoveOrder(Order order)
    {
        _appDbContext.Remove(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }
}


