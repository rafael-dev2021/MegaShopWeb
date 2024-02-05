using Domain.Entities.Payments.Algorithms.ACreditCard;
using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payments.Valuables;

public class PaymentMethodObjectValue : IPaymentMethod
{
    [EnumDataType(typeof(EPaymentMethod))]
    public string PaymentMethod { get; protected set; }

    [NotMapped]
    public EPaymentMethod EPaymentMethod { get; protected set; }

    public Guid Reference { get; set; }
    public PaymentStatusObjectValue PaymentStatusObjectValue { get; set; } = new PaymentStatusObjectValue();
    public DateTime PaymentDate { get; protected set; }

    public void PaymentDateConfirm()
    {
        PaymentDate = DateTime.Now;
    }
    private void SetReference()
    {
        Reference = Guid.NewGuid();
    }
    public void CreditCardPaymentMethod(string creditCardNumber)
    {
        EPaymentMethod = EPaymentMethod.CreditCard;
        PaymentMethod = EPaymentMethod.CreditCard.ToString();

        bool isCreditCardPaymentCompleted = CreditCardValidator.ValidateCreditCardNumber(creditCardNumber);

        if (isCreditCardPaymentCompleted && PaymentStatusObjectValue != null)
        {
            PaymentStatusObjectValue.PaymentApproved();
            SetReference();
            PaymentDateConfirm();
        }
        else
        {
            PaymentStatusObjectValue.PaymentDeclined();
        }
    }

    public void DebitCardPaymentMethod(string debitCardNumber)
    {
        EPaymentMethod = EPaymentMethod.DebitCard;
        PaymentMethod = EPaymentMethod.DebitCard.ToString();

        bool isDebitCardPaymentCompleted = CreditCardValidator.ValidateCreditCardNumber(debitCardNumber);

        if (isDebitCardPaymentCompleted && PaymentStatusObjectValue != null)
        {
            PaymentStatusObjectValue.PaymentApproved();
            SetReference();
            PaymentDateConfirm();
        }
        else
        {
            PaymentStatusObjectValue.PaymentDeclined();
        }
    }

    public void BankSlipPaymentMethod()
    {
        EPaymentMethod = EPaymentMethod.BankSlip;
        PaymentMethod = EPaymentMethod.BankSlip.ToString();
        SetReference();
        PaymentDateConfirm();
    }
}
