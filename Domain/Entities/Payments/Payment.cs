using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Payments
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public DateTime ProcessingDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public EPaymentMethod EPaymentMethod { get; set; }
        public EPaymentStatus EPaymentStatus { get; set; }
        public decimal Amount { get; set; }

        protected Payment(int id, DateTime processingDate, DateTime paymentDate, EPaymentMethod ePaymentMethod, EPaymentStatus ePaymentStatus, decimal amount)
        {
            Id = id;
            ProcessingDate = processingDate;
            PaymentDate = paymentDate;
            EPaymentMethod = ePaymentMethod;
            EPaymentStatus = ePaymentStatus;
            Amount = amount;
        }

        public virtual void Pay() { }
    }
}
