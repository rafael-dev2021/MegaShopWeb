using Domain.Entities.Payments.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.PaymentsDto;

public class PaymentDto
{
    public int Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public EPaymentStatus EPaymentStatus { get; set; }
    public EPaymentMethod EPaymentMethod { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }
    public string SSN { get; set; }
    public Guid Reference { get; set; }
}
