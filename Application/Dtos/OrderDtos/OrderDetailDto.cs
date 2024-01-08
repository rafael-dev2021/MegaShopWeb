using Application.Dtos.PaymentsDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.OrderDtos;

public class OrderDetailDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product{ get; set; }
    public int OrderId { get; set; }
    public  OrderDto Order{ get; set; }
    public int PaymentId { get; set; }
    public PaymentDto Payment{ get; set; }
}
