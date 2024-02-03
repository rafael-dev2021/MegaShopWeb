namespace Domain.Entities.Payments.Interfaces;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListPaymentsAsync();
}
