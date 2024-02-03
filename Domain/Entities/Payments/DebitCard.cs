namespace Domain.Entities.Payments;

public class DebitCard
{
    public Guid Id { get; set; }
    public string DebitCardNumber { get; private set; } = string.Empty;
    public string DebitCardHolderName { get; private set; } = string.Empty;
    public string DebitCardExpirationDate { get; private set; } = string.Empty;
    public string DebitCardCVV { get; private set; } = string.Empty;
}
