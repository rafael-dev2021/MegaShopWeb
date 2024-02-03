namespace Application.Dtos.Delivery;

public class DeliveryAddressDto
{
    public string ZipCode { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
