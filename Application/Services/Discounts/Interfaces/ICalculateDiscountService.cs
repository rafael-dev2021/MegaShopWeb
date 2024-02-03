using Application.Dtos.Valuables.ProductsOV;

namespace Application.Services.Discounts.Interfaces
{
    public interface ICalculateDiscountService
    {
        decimal DiscountPercentage(ProductPriceOVDto price);
        decimal InTwelveInstallmentWithoutInterest(ProductPriceOVDto price);
        decimal InSixInstallmentWithoutInterest(ProductPriceOVDto price);
        decimal InThreeInstallmentWithInterest(ProductPriceOVDto price);
    }
}
