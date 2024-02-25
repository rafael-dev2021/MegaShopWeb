namespace Domain.Entities.Payments;

public sealed class CreditCard
{
    public Guid Id { get; set; } = new Guid();
    public string CreditCardNumber { get; private set; } = string.Empty;
    public string CreditCardHolderName { get; private set; } = string.Empty;
    public string CreditCardExpirationDate { get; private set; } = string.Empty;
    public string CreditCardCVV { get; private set; } = string.Empty;
    public string SSN { get; private set; } = string.Empty;
}
