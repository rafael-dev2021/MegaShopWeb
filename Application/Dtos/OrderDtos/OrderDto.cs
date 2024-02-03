using Application.Dtos.Delivery;
using Application.Dtos.PaymentsDto;

namespace Application.Dtos.OrderDtos;

public class OrderDto
{
    public int Id { get; set; }
    public decimal TotalOrder { get; set; }
    public int TotalItemsOrder { get; set; }
    public DateTime ConfirmedOrder { get; set; }
    public DateTime DispatchedOrder { get; set; }
    public DateTime RequestReceived { get; set; }
    public List<OrderDetailDto> OrderDetails { get; }
    public DeliveryAddressDto DeliveryAddress { get; set; }
    public UserDeliveryDto UserDelivery { get; set; }
    public PaymentMethodDto PaymentMethod{ get; set; }

}
