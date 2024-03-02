using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Payments;

public class PaymentMethod : Payment
{
    public CreditCard CreditCard { get; set; } = new();
    public DebitCard DebitCard { get; set; } = new();

    public override void DefaultPayment(EPaymentMethod ePaymentMethod)
    {
        switch (ePaymentMethod)
        {
            case EPaymentMethod.CreditCard:
                PaymentMethodObjectValue.CreditCardPaymentMethod(CreditCard.CardNumber);
                break;
            case EPaymentMethod.DebitCard:
                PaymentMethodObjectValue.DebitCardPaymentMethod(DebitCard.CardNumber);
                break;
        }
    }
}


