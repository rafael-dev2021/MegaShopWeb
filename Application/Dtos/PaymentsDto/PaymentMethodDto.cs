namespace Application.Dtos.PaymentsDto;

public class PaymentMethodDto : PaymentDto
{
    public CreditCardDto CreditCard{ get; set; }
    public DebitCardDto DebitCard{ get; set; }
}
