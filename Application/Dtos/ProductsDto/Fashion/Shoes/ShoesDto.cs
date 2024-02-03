using Application.Dtos.ProductsDto.Fashion.Shoes.Valuables;

namespace Application.Dtos.ProductsDto.Fashion.Shoes;

public class ShoesDto : ProductDto
{
    public ShoesDesignOVDto ShoesDesignObjectValue { get; set; }
    public ShoesGeneralFeaturesOVDto ShoesGeneralFeaturesObjectValue { get; set; }
    public ShoesMaterialsOVDto ShoesMaterialsObjectValue { get; set; }
    public ShoesSpecificationsOVDto ShoesSpecificationsObjectValue { get; set; }
}
