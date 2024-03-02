namespace Domain.Entities.Payments;

public abstract class Card
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CardNumber { get; private set; } = string.Empty;
    public string CardHolderName { get; private set; } = string.Empty;
    public string CardExpirationDate { get; private set; } = string.Empty;
    public string CardCVV { get; private set; } = string.Empty;
    public string SSN { get; private set; } = string.Empty;
}
