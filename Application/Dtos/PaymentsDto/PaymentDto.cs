using Domain.Entities.Orders;
using Domain.Entities.Payments.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.PaymentsDto;

public class PaymentDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please select a payment method.")]
    public string PaymentMethod { get; set; }

    [Required(ErrorMessage = "Please enter your card number.")]
    [CreditCard(ErrorMessage = "Please provide a valid card number.")]
    [StringLength(19, MinimumLength = 12)]
    public string CardNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the name on the card.")]
    [StringLength(50)]
    public string CardHolderName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the card expiration date.")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Please enter a valid expiration date (MM/YY).")]
    [StringLength(5)]
    public string ExpirationDate { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the card security code.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid security code.")]
    [StringLength(4)]
    public string SecurityCode { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Amount { get; set; }
    public DateTime ProcessingDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public EPaymentMethod EPaymentMethod { get; set; }
    public EPaymentStatus EPaymentStatus { get; set; }
    public Guid Reference { get; set; } = new Guid();
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
}
