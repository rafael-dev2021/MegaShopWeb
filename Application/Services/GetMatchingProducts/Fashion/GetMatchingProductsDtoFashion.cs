using Application.Dtos;
using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Dtos.ProductsDto.Fashion.Tshirts;

namespace Application.Services.GetMatchingProducts.Fashion
{
    public class GetMatchingProductsDtoFashion
    {
        public ProductDto ProductDto { get; set; }
        public IEnumerable<TshirtDto> TshirtsDto { get; set; }
        public IEnumerable<ShoesDto> ShoesDtos { get; set; }

        public IEnumerable<TshirtDto> GetMatchingTshirt()
        {
            var matchingSmartTvs = TshirtsDto.Where(s =>
                s.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
                s.Category.CategoryName == ProductDto.Category.CategoryName);

            return matchingSmartTvs;
        }
        public IEnumerable<ShoesDto> GetMatchingShoes()
        {
            var matchingSmartTvs = ShoesDtos.Where(s =>
                s.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
                s.Category.CategoryName == ProductDto.Category.CategoryName);

            return matchingSmartTvs;
        }
    }
}
