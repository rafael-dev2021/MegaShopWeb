using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payments.Valuables;

public class PaymentStatusObjectValue : IPaymentStatus
{
    [EnumDataType(typeof(EPaymentStatus))]
    public string PaymentStatus { get; protected set; }

    [NotMapped]
    public EPaymentStatus EPaymentStatus { get; protected set; }

    public void SetPaymentStatus(EPaymentStatus status)
    {
        EPaymentStatus = status;
        PaymentStatus = status.ToString();
    }
    public void PaymentPending() => SetPaymentStatus(EPaymentStatus.Pending);
    public void PaymentProcessing() => SetPaymentStatus(EPaymentStatus.Processing);
    public void PaymentApproved() => SetPaymentStatus(EPaymentStatus.Approved);
    public void PaymentDeclined() => SetPaymentStatus(EPaymentStatus.Declined);
    public void PaymentRefunded() => SetPaymentStatus(EPaymentStatus.Refunded);
    public void PaymentCompleted() => SetPaymentStatus(EPaymentStatus.Completed);
    public void PaymentCanceled() => SetPaymentStatus(EPaymentStatus.Canceled);
}
