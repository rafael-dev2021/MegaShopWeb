using Application.Dtos.Valuables.ProductsOV;
using Application.Services.Discounts.Interfaces;

namespace Application.Services.Discounts;

public class CalculateDiscountService : ICalculateDiscountService
{
    public decimal DiscountPercentage(ProductPriceOVDto price)
    {
        if (price.HistoryPrice > 0)
        {
            var calculate = (price.HistoryPrice - price.Price) / price.HistoryPrice * 100;
            return calculate;
        }
        return 0;
    }

    public decimal InSixInstallmentWithoutInterest(ProductPriceOVDto price)
    {
        var calculate = price.Price / 6;
        return calculate;
    }

    public decimal InThreeInstallmentWithInterest(ProductPriceOVDto price)
    {
        var calculate = price.Price / 3;
        var addingInterest = calculate * 1.03m;
        return addingInterest;
    }

    public decimal InTwelveInstallmentWithoutInterest(ProductPriceOVDto price)
    {
        var calculate = price.Price / 12;
        return calculate;
    }
}
