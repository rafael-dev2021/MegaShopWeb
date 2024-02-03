using Application.Dtos;

namespace Application.Services.PriceIsHigherThan;

public class PriceIsHigherThanServiceBooleans
{
    public ProductDto ProductDto { get; set; }
    public bool IsPriceHigherThanTwoThousand
    {
        get { return ProductDto.ProductPriceObjectValue.Price >= 2000; }
    }
    public bool IsPriceIsBetweenTwoHundredAndAThousand
    {
        get
        {
            return
                ProductDto.ProductPriceObjectValue.Price >= 200 &&
                ProductDto.ProductPriceObjectValue.Price <= 1000;
        }
    }
    public bool IsPriceIsLowerThanOneHundred
    {
        get { return ProductDto.ProductPriceObjectValue.Price <= 100; }
    }
}
