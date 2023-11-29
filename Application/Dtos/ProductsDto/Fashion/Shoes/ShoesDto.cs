using Application.Dtos.ProductsDto.Fashion.Shoes.ObjectsValue;

namespace Application.Dtos.ProductsDto.Fashion.Shoes
{
    public sealed class ShoesDto : ProductDto
    {
        public ShoesDesignOVDto ShoesDesignObjectValue { get; set; }
        public ShoesGeneralFeaturesOVDto ShoesGeneralFeaturesObjectValue { get; set; }
        public ShoesMaterialsOVDto ShoesMaterialsObjectValue { get; set; }
        public ShoesSpecificationsOVDto ShoesSpecificationsObjectValue { get; set; }
    }
}
