using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Payments;

public class PaymentMethod : Payment
{
    public CreditCard CreditCard { get; set; }
    public DebitCard DebitCard { get; set; }

    public override void DefaultPayment(EPaymentMethod ePaymentMethod)
    {
        switch (ePaymentMethod)
        {
            case EPaymentMethod.CreditCard:
                PaymentMethodObjectValue.CreditCardPaymentMethod(CreditCard.CreditCardNumber);
                break;
            case EPaymentMethod.DebitCard:
                PaymentMethodObjectValue.DebitCardPaymentMethod(DebitCard.DebitCardNumber);
                break;
            case EPaymentMethod.PayPal:
                PaymentMethodObjectValue.PayPalPaymentMethod();
                break;
            case EPaymentMethod.BankTransfer:
                PaymentMethodObjectValue.TransferPaymentMethod();
                break;
            case EPaymentMethod.CashOnDelivery:
                PaymentMethodObjectValue.MoneyPaymentMethod();
                break;
        }
    }
}
