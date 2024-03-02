using Domain.Entities.Payments.Valuables;

namespace Application.Dtos.PaymentsDto;

public class PaymentDto
{
    public int Id { get; set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; set; } = new PaymentMethodObjectValue();
    public decimal Amount { get; set; }
    public string SSN { get; set; }
}
