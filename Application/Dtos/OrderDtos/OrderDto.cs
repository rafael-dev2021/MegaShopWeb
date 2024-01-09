using Application.Dtos.PaymentsDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.OrderDtos;

public class OrderDto
{
    public int Id { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "CPF is required")]
    [StringLength(14)]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Invalid CPF format")]
    public string Cpf { get; set; }


    [Required]
    [StringLength(8, MinimumLength = 8)]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Cep.")]
    public string Cep { get; set; }


    [Required]
    [StringLength(60, MinimumLength = 4)]
    public string Address { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 10)]
    public string Complement { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 2)]
    public string State { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 2)]
    public string City { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 2)]
    public string Neighborhood { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 9)]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only digits.")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    public string Country { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalOrder { get; set; }
    public int TotalItemsOrder { get; set; }
    public DateTime ConfirmedOrder { get; set; }
    public DateTime DispatchedOrder { get; set; }
    public DateTime RequestReceived { get; set; }

    public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    public PaymentDto Payment { get; set; }
}
