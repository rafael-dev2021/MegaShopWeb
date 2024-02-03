using Application.Dtos.ProductsDto.Technology.Games.Valuables;

namespace Application.Dtos.ProductsDto.Technology.Games;

public class GameDto : ProductDto
{
    public GameGeneralFeaturesOVDto GameGeneralFeaturesObjectsValue { get; set; }
    public GameSpecificationsOVDto GameSpecificationsObjectsValue { get; set; }
    public GameRequirementsOVDto GameRequirementsObjectsValue { get; set; }
}
