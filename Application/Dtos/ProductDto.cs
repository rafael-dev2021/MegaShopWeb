using Application.Dtos.ValueObjects.ProductsOV;
using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.ValueObjects;
using Application.Services.Discounts;
using Domain.Entities;
using Domain.Entities.Reviews;
using System.ComponentModel;

namespace Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public ProductDataOVDto ProductDataObjectValue { get; set; }
        public ProductFlagsOVDto ProductFlagsObjectValue { get; set; }
        public ProductImageOVDto ProductImageObjectValue { get; set; }
        public ProductPriceOVDto ProductPriceObjectValue { get; set; }
        public ProductSpecificationsOVDto ProductSpecificationsObjectValue { get; set; }
        public ProductWarrantyOVDto ProductWarrantyObjectValue { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }
        //public ICollection<ShoppingCartItem> ShoppingCartItens { get; set; }

        public CalculateDiscountService CalculateDiscountService()
        {
            var calculateDiscount = new CalculateDiscountService();
            return calculateDiscount;
        }

        public WeightedAverageResultOV CalculateWeightedAverage()
        {
            var weightedAverageCalculator = new WeightedAverageCalculator();
            return weightedAverageCalculator.CalculateWeightedAverage(Reviews);
        }
    }
}
