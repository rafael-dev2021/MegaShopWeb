using Application.Dtos.Reviews;
using Application.Dtos.Valuables.ProductsOV;
using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.ValueObjects;
using Application.Services.Discounts;
using Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 10, ErrorMessage = "Maximum 60 and minimum 10 characters")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "Maximum 10000 and minimum 10 characters")]
    [Display(Name = "Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The first image is required.")]
    public List<string> Images { get; set; }

    [Required]
    [Range(1, 999)]
    [Display(Name = "Stock")]
    public int Stock { get; set; }
    public ProductDataOVDto ProductDataObjectValue { get; set; }
    public ProductFlagsOVDto ProductFlagsObjectValue { get; set; }
    public ProductPriceOVDto ProductPriceObjectValue { get; set; }
    public ProductSpecificationsOVDto ProductSpecificationsObjectValue { get; set; }
    public ProductWarrantyOVDto ProductWarrantyObjectValue { get; set; }

    [DisplayName("Categories")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<ReviewDto> Reviews { get; set; }

    public CalculateDiscountService CalculateDiscountService() => new();

    public WeightedAverageResultOV CalculateWeightedAverage()
    {
        var weightedAverageCalculator = new WeightedAverageCalculator();
        return weightedAverageCalculator.CalculateWeightedAverage(Reviews);
    }
}
