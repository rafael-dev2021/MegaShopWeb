using Application.Dtos.PaymentsDto;

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
    public CreditCardDto CreditCard { get; set; }
}
