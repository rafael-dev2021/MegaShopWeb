namespace Domain.Entities.Delivery;

public class DeliveryAddress
{
    public string ZipCode { get; protected set; } = string.Empty;
    public string Address { get; protected set; } = string.Empty;
    public string Complement { get; protected set; } = string.Empty;
    public string State { get; protected set; } = string.Empty;
    public string City { get; protected set; } = string.Empty;
    public string Neighborhood { get; protected set; } = string.Empty;
    public string Country { get; protected set; } = string.Empty;
}
