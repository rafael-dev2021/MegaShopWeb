using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.Valuables;

namespace Domain.Entities.Payments;

public abstract class Payment
{
    public int Id { get; set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; set; } = new PaymentMethodObjectValue();
    public decimal Amount { get; protected set; }
    public string SSN { get; protected set; }
    public abstract void DefaultPayment(EPaymentMethod ePaymentMethod);
}
