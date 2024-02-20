using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Delivery;

public class DeliveryAddressDto
{
    [Required]
    [StringLength(60, MinimumLength = 4)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(8, MinimumLength = 8)]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Zip Code.")]
    public string ZipCode { get; set; } = string.Empty;

    [Required]
    [StringLength(60, MinimumLength = 10)]
    public string Complement { get; set; } = string.Empty;

    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string State { get; set; } = string.Empty;

    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(30, MinimumLength = 2)]
    public string Neighborhood { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;
}
