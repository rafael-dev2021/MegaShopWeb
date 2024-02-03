using Domain.Entities.Products.Fashion.ProductShoes;
using Domain.Entities.Valuables.ProductValuables;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.ProductShoes;

public class ShoesCommand : IRequest<Shoes>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }
    public int Stock { get; set; }
    public ProductDataOV ProductDataObjectValue { get; set; }
    public ProductFlagsOV ProductFlagsObjectValue { get; set; }
    public ProductPriceOV ProductPriceObjectValue { get; set; }
    public ProductSpecificationsOV ProductSpecificationsObjectValue { get; set; }
    public ProductWarrantyOV ProductWarrantyObjectValue { get; set; }
    public ShoesDesignOV ShoesDesignObjectValue { get; set; }
    public ShoesGeneralFeaturesOV ShoesGeneralFeaturesObjectValue { get; set; }
    public ShoesMaterialsOV ShoesMaterialsObjectValue { get; set; }
    public ShoesSpecificationsOV ShoesSpecificationsObjectValue { get; set; }
    public int CategoryId { get; set; }
}
