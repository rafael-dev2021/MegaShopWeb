using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Fashion.Tshirts.Valuables;
using Domain.Entities.Valuables.ProductValuables;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Tshirts;

public class TshirtCommand : IRequest<Tshirt>
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
    public TshirtOtherFeaturesOV TshirtOtherFeaturesObectsValue { get; set; }
    public TshirtMainFeaturesOV TshirtMainFeaturesObectsValue { get; set; }
    public int CategoryId { get; set; }
}
