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

    public void PaymentPending()
    {
        EPaymentStatus = EPaymentStatus.Pending;
        PaymentStatus = EPaymentStatus.Pending.ToString();
    }

    public void PaymentProcessing()
    {
        EPaymentStatus = EPaymentStatus.Processing;
        PaymentStatus = EPaymentStatus.Processing.ToString();
    }

    public void PaymentApproved()
    {
        EPaymentStatus = EPaymentStatus.Approved;
        PaymentStatus = EPaymentStatus.Approved.ToString();
    }

    public void PaymentDeclined()
    {
        EPaymentStatus = EPaymentStatus.Declined;
        PaymentStatus = EPaymentStatus.Declined.ToString();
    }

    public void PaymentRefunded()
    {
        EPaymentStatus = EPaymentStatus.Refunded;
        PaymentStatus = EPaymentStatus.Refunded.ToString();
    }

    public void PaymentCompleted()
    {
        EPaymentStatus = EPaymentStatus.Completed;
        PaymentStatus = EPaymentStatus.Completed.ToString();
    }

    public void PaymentCanceled()
    {
        EPaymentStatus = EPaymentStatus.Canceled;
        PaymentStatus = EPaymentStatus.Canceled.ToString();
    }
}
