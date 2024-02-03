using Domain.Entities.Products.Technology.Smartphones.Valuables;
using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities.Products.Technology.Smartphones;

public sealed class Smartphone : Product
{
    public Smartphone(int id, string name, string description, List<string> images, int stock, int categoryId) : base(id, name, description, images, stock, categoryId)
    { }
    public Smartphone(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue, 
        ProductWarrantyOV productWarrantyObjectValue, 
        SmartphoneFeatureOV smartphoneFeatureObjectValue,
        SmartphoneDisplayOV smartphoneDisplayObjectValue,
        SmartphoneMemoryOV smartphoneMemoryObjectValue,
        SmartphoneCameraOV smartphoneCameraObjectValue, 
        SmartphonePlatformOV smartphonePlatformObjectValue, 
        SmartphoneBatteryOV smartphoneBatteryObjectValue, 
        SmartphoneDimensionsOV smartphoneDimensionsObjectValue,
        int categoryId)
       : base(
            name,
            description,
            images,
            stock,
            productDataObjectValue,
            productFlagsObjectValue,
            productPriceObjectValue,
            productSpecificationsObjectValue,
            productWarrantyObjectValue,
            categoryId)
    {
        SmartphoneFeatureObjectValue = smartphoneFeatureObjectValue;
        SmartphoneDisplayObjectValue = smartphoneDisplayObjectValue;
        SmartphoneMemoryObjectValue = smartphoneMemoryObjectValue;
        SmartphoneCameraObjectValue = smartphoneCameraObjectValue;
        SmartphonePlatformObjectValue = smartphonePlatformObjectValue;
        SmartphoneBatteryObjectValue = smartphoneBatteryObjectValue;
        SmartphoneDimensionsObjectValue = smartphoneDimensionsObjectValue;
    }

    public void SmartphoneUpdate(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue, 
        ProductPriceOV productPriceObjectValue, 
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue, 
        SmartphoneFeatureOV smartphoneFeatureObjectValue, 
        SmartphoneDisplayOV smartphoneDisplayObjectValue,
        SmartphoneMemoryOV smartphoneMemoryObjectValue, 
        SmartphoneCameraOV smartphoneCameraObjectValue, 
        SmartphonePlatformOV smartphonePlatformObjectValue,
        SmartphoneBatteryOV smartphoneBatteryObjectValue,
        SmartphoneDimensionsOV smartphoneDimensionsObjectValue,
        int categoryId)
    {
        ProductUpdate(
            name, 
            description,
            images,
            stock, 
            productDataObjectValue,
            productFlagsObjectValue,
            productPriceObjectValue, 
            productSpecificationsObjectValue,
            productWarrantyObjectValue, 
            categoryId);

        SmartphoneFeatureObjectValue = smartphoneFeatureObjectValue;
        SmartphoneDisplayObjectValue = smartphoneDisplayObjectValue;
        SmartphoneMemoryObjectValue = smartphoneMemoryObjectValue;
        SmartphoneCameraObjectValue = smartphoneCameraObjectValue;
        SmartphonePlatformObjectValue = smartphonePlatformObjectValue;
        SmartphoneBatteryObjectValue = smartphoneBatteryObjectValue;
        SmartphoneDimensionsObjectValue = smartphoneDimensionsObjectValue;
    }
    public SmartphoneFeatureOV SmartphoneFeatureObjectValue { get;  private set; }
    public SmartphoneDisplayOV SmartphoneDisplayObjectValue { get; private set; }
    public SmartphoneMemoryOV SmartphoneMemoryObjectValue { get; private set; }
    public SmartphoneCameraOV SmartphoneCameraObjectValue { get; private set; }
    public SmartphonePlatformOV SmartphonePlatformObjectValue { get; private set; }
    public SmartphoneBatteryOV SmartphoneBatteryObjectValue { get; private set; }
    public SmartphoneDimensionsOV SmartphoneDimensionsObjectValue { get; private set; }

}
