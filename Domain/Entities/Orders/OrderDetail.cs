using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class OrderDetail(int quantity, decimal price, int orderId, int productId, int paymentMethodId)
{
    public int Id { get; set; }
    public int Quantity { get; protected set; } = quantity;
    public decimal Price { get; protected set; } = price;
    public int ProductId { get; protected set; } = productId;
    public Product Product { get; protected set; }
    public int OrderId { get; protected set; } = orderId;
    public Order Order { get; protected set; }
    public int PaymentMethodId { get; protected set; } = paymentMethodId;
    public PaymentMethod PaymentMethod { get; protected set; }
}
