namespace Domain.Entities.Payments.Interfaces;

public interface IPaymentMethod
{
    void CreditCardPaymentMethod(string creditCardNumber);
    void DebitCardPaymentMethod(string debitCardNumber);
    void PayPalPaymentMethod();
    void MoneyPaymentMethod();
    void TransferPaymentMethod();
}
