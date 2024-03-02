using Domain.Entities.Delivery;
using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class Order
{
    public int Id { get; set; }
    public decimal TotalOrder { get; protected set; }
    public int TotalItemsOrder { get; protected set; }
    public DateTime ConfirmedOrder { get; protected set; }
    public DateTime DispatchedOrder { get; protected set; }
    public DateTime RequestReceived { get; protected set; }
    public List<OrderDetail> OrderDetails { get; protected set; } = [];
    public DeliveryAddress DeliveryAddress { get; protected set; } = new DeliveryAddress();
    public UserDelivery UserDelivery { get; protected set; } = new UserDelivery();
    public PaymentMethod PaymentMethod { get; set; }


    public void Update(DateTime dispatchedOrder, DateTime requestReceived)
    {
        DispatchedOrder = dispatchedOrder;
        RequestReceived = requestReceived;
    }

    public void WhenConfirmedOrder()
    {
        ConfirmedOrder = DateTime.Now;
    }
}

