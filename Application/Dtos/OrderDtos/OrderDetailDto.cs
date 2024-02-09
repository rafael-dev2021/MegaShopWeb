using Application.Dtos.PaymentsDto;
using Domain.Entities.Orders;

namespace Application.Dtos.OrderDtos;

public class OrderDetailDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int OrderId { get; set; }
    public OrderDto Order { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethodDto PaymentMethod { get; set; }
}
