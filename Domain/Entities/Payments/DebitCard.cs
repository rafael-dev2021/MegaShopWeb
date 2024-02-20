namespace Domain.Entities.Payments;

public class DebitCard
{
    public Guid Id { get; set; } = new Guid();
    public string DebitCardNumber { get; private set; } = string.Empty;
    public string DebitCardHolderName { get; private set; } = string.Empty;
    public string DebitCardExpirationDate { get; private set; } = string.Empty;
    public string DebitCardCVV { get; private set; } = string.Empty;
}
