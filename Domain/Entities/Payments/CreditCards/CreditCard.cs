using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Payments.CreditCards
{
    public class CreditCard(int id, DateTime processingDate, DateTime paymentDate, EPaymentMethod ePaymentMethod, EPaymentStatus ePaymentStatus, decimal amount, string cardNumber, string cardHolderName, string expirationDate, string cVV, Guid reference) : Payment(id, processingDate, paymentDate, ePaymentMethod, ePaymentStatus, amount)
    {
        public string CardNumber { get; set; } = cardNumber;
        public string CardHolderName { get; set; } = cardHolderName;
        public string ExpirationDate { get; set; } = expirationDate;
        public string CVV { get; set; } = cVV;
        public Guid Reference { get; set; } = reference;
        public override void Pay()
        {
            base.Pay();
        }
    }
}
