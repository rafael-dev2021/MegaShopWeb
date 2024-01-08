using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Payments;

public class Payment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please select a payment method.")]
    public string PaymentMethod { get; set; }

    [Required(ErrorMessage = "Please enter your card number.")]
    [CreditCard(ErrorMessage = "Please provide a valid card number.")]
    public string CardNumber { get; set; }

    [Required(ErrorMessage = "Please enter the name on the card.")]
    public string CardHolderName { get; set; }

    [Required(ErrorMessage = "Please enter the card expiration date.")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Please enter a valid expiration date (MM/YY).")]
    public string ExpirationDate { get; set; }

    [Required(ErrorMessage = "Please enter the card security code.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid security code.")]
    public string SecurityCode { get; set; }
    //public string CardNumber { get; set; } 
    //public string CardHolderName { get; set; }
    //public string ExpirationDate { get; set; }
    //public string SecurityCode { get; set; } 
    //public DateTime ProcessingDate { get; set; }
    //public DateTime PaymentDate { get; set; }
    //public EPaymentMethod EPaymentMethod { get; set; }
    //public EPaymentStatus EPaymentStatus { get; set; }
    //public decimal Amount { get; set; }
    //public Guid Reference { get; set; } = new Guid();
    //public virtual void Pay(EPaymentMethod ePayment)
    //{
    //    Console.WriteLine($"Processing payment of {Amount} using {ePayment.GetDescription()} method...");

    //    EPaymentStatus = EPaymentStatus.Processing;
    //    ProcessingDate = DateTime.Now;
    //}
}
