namespace Domain.Entities.Payments.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        //Task<IEnumerable<CreditCard>> GetPaymentsCreditCardAsync();
        Task<Payment> GetByIdAsync(int? id);
    }
}
