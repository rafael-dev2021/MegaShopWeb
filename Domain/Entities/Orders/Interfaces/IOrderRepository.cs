using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Orders.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetByIdAsync(int? id);
    Task CreateOrder(Order order, EPaymentMethod ePaymentMethod);
    Task<Order> UpdateOrder(Order order);
    Task<Order> RemoveOrder(Order order);
}
