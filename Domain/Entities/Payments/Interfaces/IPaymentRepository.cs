namespace Domain.Entities.Payments.Interfaces;

public interface IPaymentRepository
{
    Task<IEnumerable<PaymentMethod>> ListPaymentsAsync();
    Task<IEnumerable<CreditCard>> ListPaymentCreditCardsAsync();
    Task<IEnumerable<DebitCard>> ListPaymentDebitCardsAsync();

    Task<PaymentMethod> GetByIdPaymentAsync(int? id);
    Task<CreditCard> GetByIdPaymentCreditCardAsync(Guid? id);
    Task<DebitCard> GetByIdPaymentDebitCardAsync(Guid? id);
    //Task<IEnumerable<Payment>> ListPaymentBankSlipAsync();
}
