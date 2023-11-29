using Application.Dtos.ProductsDto.Technology.Smartphones.ObjectsValue;

namespace Application.Dtos.ProductsDto.Technology.Smartphones
{
    public sealed class SmartphoneDto : ProductDto
    {
        public SmartphoneFeatureOVDto SmartphoneFeatureObjectValue { get; set; }
        public SmartphoneDisplayOVDto SmartphoneDisplayObjectValue { get; set; }
        public SmartphoneMemoryOVDto SmartphoneMemoryObjectValue { get; set; }
        public SmartphoneCameraOVDto SmartphoneCameraObjectValue { get; set; }
        public SmartphonePlatformOVDto SmartphonePlatformObjectValue { get; set; }
        public SmartphoneBatteryOVDto SmartphoneBatteryObjectValue { get; set; }
        public SmartphoneDimensionsOVDto SmartphoneDimensionsObjectValue { get; set; }

    }
}
