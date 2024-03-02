using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.PaymentsDto;

public class CardDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Please enter your card number.")]
    [CreditCard(ErrorMessage = "Card refused, please provide a valid card number.")]
    [StringLength(19, MinimumLength = 12)]
    public string CardNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the name on the card.")]
    [StringLength(50)]
    public string CardHolderName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the card expiration date.")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Please enter a valid expiration date (MM/YY).")]
    [StringLength(5)]
    public string CardExpirationDate { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the card security code.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid security code.")]
    [StringLength(4)]
    public string CardCVV { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
}
