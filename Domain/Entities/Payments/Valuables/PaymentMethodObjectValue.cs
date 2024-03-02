using Domain.Entities.Payments.Algorithms.ACreditCard;
using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payments.Valuables;

public class PaymentMethodObjectValue : IPaymentMethod
{
    public PaymentStatusObjectValue PaymentStatusObjectValue { get; protected set; } = new ();
    [EnumDataType(typeof(EPaymentMethod))]
    public string PaymentMethod { get; protected set; } = string.Empty;

    [NotMapped]
    public EPaymentMethod EPaymentMethod { get; protected set; }

    public Guid Reference { get; protected set; }
    public DateTime PaymentDate { get; protected set; }

    private void PaymentDateConfirm() => PaymentDate = DateTime.Now;
    private void SetReference() => Reference = Guid.NewGuid();

    private void ProcessPayment(string cardNumber, EPaymentMethod method)
    {
        EPaymentMethod = method;
        PaymentMethod = method.ToString();
        bool isPaymentCompleted = CreditCardValidator
            .ValidateCreditCardNumber(cardNumber);
        if (isPaymentCompleted && PaymentStatusObjectValue != null)
        {
            PaymentStatusObjectValue.PaymentProcessing();
            SetReference();

            Thread.Sleep(2500);

            PaymentStatusObjectValue.PaymentApproved();
            PaymentDateConfirm();
        }
        else
        {
            PaymentStatusObjectValue?.PaymentDeclined();
        }
    }

    public void CreditCardPaymentMethod(string cardNumber)
    {
        ProcessPayment(cardNumber, EPaymentMethod.CreditCard);
    }

    public void DebitCardPaymentMethod(string cardNumber)
    {
        ProcessPayment(cardNumber, EPaymentMethod.DebitCard);
    }

    public void BankSlipPaymentMethod()
    {
        EPaymentMethod = EPaymentMethod.BankSlip;
        PaymentMethod = EPaymentMethod.BankSlip.ToString();
        SetReference();
        PaymentDateConfirm();
    }
}
