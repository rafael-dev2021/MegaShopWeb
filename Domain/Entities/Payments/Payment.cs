using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.Valuables;

namespace Domain.Entities.Payments;

public abstract class Payment
{
    public int Id { get; protected set; }
    public string Ssn { get; protected set; } = string.Empty;
    public decimal Amount { get; protected set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; protected set; } = new();

    public abstract void DefaultPayment(EPaymentMethod ePaymentMethod);
}
