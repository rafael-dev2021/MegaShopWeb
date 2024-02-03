using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones.Valuables;
using Domain.Entities.Valuables.ProductValuables;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Smartphones;

public class SmartphoneCommand : IRequest<Smartphone>
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
    public SmartphoneFeatureOV SmartphoneFeatureObjectValue { get; set; }
    public SmartphoneDisplayOV SmartphoneDisplayObjectValue { get; set; }
    public SmartphoneMemoryOV SmartphoneMemoryObjectValue { get; set; }
    public SmartphoneCameraOV SmartphoneCameraObjectValue { get; set; }
    public SmartphonePlatformOV SmartphonePlatformObjectValue { get; set; }
    public SmartphoneBatteryOV SmartphoneBatteryObjectValue { get; set; }
    public SmartphoneDimensionsOV SmartphoneDimensionsObjectValue { get; set; }
    public int CategoryId { get; set; }
}
