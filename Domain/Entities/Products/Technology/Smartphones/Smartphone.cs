using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Technology.Smartphones.ObjectsValue;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public SmartphoneFeatureOV SmartphoneFeatureObjectValue { get; set; }
        [Required]
        public SmartphoneDisplayOV SmartphoneDisplayObjectValue { get; set; }
        [Required]
        public SmartphoneMemoryOV SmartphoneMemoryObjectValue { get; set; }
        [Required]
        public SmartphoneCameraOV SmartphoneCameraObjectValue { get; set; }
        [Required]
        public SmartphonePlatformOV SmartphonePlatformObjectValue { get; set; }
        [Required]
        public SmartphoneBatteryOV SmartphoneBatteryObjectValue { get; set; }
        [Required]
        public SmartphoneDimensionsOV SmartphoneDimensionsObjectValue { get; set; }

    }
}
