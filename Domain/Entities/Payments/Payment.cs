namespace Domain.Entities.Payments;

public class Payment
{
    public int Id { get; set; }
    public string PaymentMethod { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string SecurityCode { get; set; }
  
    //public DateTime ProcessingDate { get; set; }
    //public DateTime PaymentDate { get; set; }
    //public EPaymentMethod EPaymentMethod { get; set; }
    //public EPaymentStatus EPaymentStatus { get; set; }
    //public decimal Amount { get; set; }
    //public Guid Reference { get; set; } = new Guid();
    //public virtual void Pay(EPaymentMethod ePayment)
    //{
    //    Console.WriteLine($"Processing payment of {Amount} using {ePayment.GetDescription()} method...");

    //    EPaymentStatus = EPaymentStatus.Processing;
    //    ProcessingDate = DateTime.Now;
    //}
}
