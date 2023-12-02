using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Technology.Smartphones.ObjectsValue;

namespace Domain.Entities.Products.Technology.Smartphones
{
    public sealed class Smartphone : Product
    {
        public Smartphone() { }
        public Smartphone(int id, string name, string description, int stock, int categoryId) : base(id, name, description, stock, categoryId)
        {
        }
        public Smartphone(int id, string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, SmartphoneFeatureOV smartphoneFeatureObjectValue, SmartphoneDisplayOV smartphoneDisplayObjectValue, SmartphoneMemoryOV smartphoneMemoryObjectValue, SmartphoneCameraOV smartphoneCameraObjectValue, SmartphonePlatformOV smartphonePlatformObjectValue, SmartphoneBatteryOV smartphoneBatteryObjectValue, SmartphoneDimensionsOV smartphoneDimensionsObjectValue, int categoryId)
            : base(id, name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            SmartphoneFeatureObjectValue = smartphoneFeatureObjectValue;
            SmartphoneDisplayObjectValue = smartphoneDisplayObjectValue;
            SmartphoneMemoryObjectValue = smartphoneMemoryObjectValue;
            SmartphoneCameraObjectValue = smartphoneCameraObjectValue;
            SmartphonePlatformObjectValue = smartphonePlatformObjectValue;
            SmartphoneBatteryObjectValue = smartphoneBatteryObjectValue;
            SmartphoneDimensionsObjectValue = smartphoneDimensionsObjectValue;
        }
        public Smartphone(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, SmartphoneFeatureOV smartphoneFeatureObjectValue, SmartphoneDisplayOV smartphoneDisplayObjectValue, SmartphoneMemoryOV smartphoneMemoryObjectValue, SmartphoneCameraOV smartphoneCameraObjectValue, SmartphonePlatformOV smartphonePlatformObjectValue, SmartphoneBatteryOV smartphoneBatteryObjectValue, SmartphoneDimensionsOV smartphoneDimensionsObjectValue, int categoryId)
           : base(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            SmartphoneFeatureObjectValue = smartphoneFeatureObjectValue;
            SmartphoneDisplayObjectValue = smartphoneDisplayObjectValue;
            SmartphoneMemoryObjectValue = smartphoneMemoryObjectValue;
            SmartphoneCameraObjectValue = smartphoneCameraObjectValue;
            SmartphonePlatformObjectValue = smartphonePlatformObjectValue;
            SmartphoneBatteryObjectValue = smartphoneBatteryObjectValue;
            SmartphoneDimensionsObjectValue = smartphoneDimensionsObjectValue;
        }

        public void SmartphoneUpdate(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, SmartphoneFeatureOV smartphoneFeatureObjectValue, SmartphoneDisplayOV smartphoneDisplayObjectValue, SmartphoneMemoryOV smartphoneMemoryObjectValue, SmartphoneCameraOV smartphoneCameraObjectValue, SmartphonePlatformOV smartphonePlatformObjectValue, SmartphoneBatteryOV smartphoneBatteryObjectValue, SmartphoneDimensionsOV smartphoneDimensionsObjectValue, int categoryId)
        {
            ProductUpdate(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId);
            SmartphoneFeatureObjectValue = smartphoneFeatureObjectValue;
            SmartphoneDisplayObjectValue = smartphoneDisplayObjectValue;
            SmartphoneMemoryObjectValue = smartphoneMemoryObjectValue;
            SmartphoneCameraObjectValue = smartphoneCameraObjectValue;
            SmartphonePlatformObjectValue = smartphonePlatformObjectValue;
            SmartphoneBatteryObjectValue = smartphoneBatteryObjectValue;
            SmartphoneDimensionsObjectValue = smartphoneDimensionsObjectValue;
        }
        public SmartphoneFeatureOV SmartphoneFeatureObjectValue { get; set; }
        public SmartphoneDisplayOV SmartphoneDisplayObjectValue { get; set; }
        public SmartphoneMemoryOV SmartphoneMemoryObjectValue { get; set; }
        public SmartphoneCameraOV SmartphoneCameraObjectValue { get; set; }
        public SmartphonePlatformOV SmartphonePlatformObjectValue { get; set; }
        public SmartphoneBatteryOV SmartphoneBatteryObjectValue { get; set; }
        public SmartphoneDimensionsOV SmartphoneDimensionsObjectValue { get; set; }

    }
}
