namespace Domain.Entities.Payments.Interfaces;

public interface IPaymentStatus
{
    void PaymentPending();
    void PaymentProcessing();
    void PaymentApproved();
    void PaymentDeclined();
    void PaymentRefunded();
    void PaymentCompleted();
    void PaymentCanceled();
}
