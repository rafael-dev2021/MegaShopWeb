using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.Dtos.ProductsDto.Technology.Smartphones;
using Application.Dtos.ProductsDto.Technology.Smartphones.ObjectsValue;
using AutoMapper;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones.ObjectsValue;

namespace Application.Mappings.Products.Technology.Smartphones
{
    public class DomainToMappingSmartphoneProfile : Profile
    {
        public DomainToMappingSmartphoneProfile()
        {
            CreateMap<Smartphone, SmartphoneDto>().ReverseMap();
            CreateMap<SmartphoneDto, CreateSmartphoneCommand>();
            CreateMap<SmartphoneDto, UpdateSmartphoneCommand>();
            CreateMap<SmartphoneFeatureOV, SmartphoneFeatureOVDto>().ReverseMap();
            CreateMap<SmartphoneDisplayOV, SmartphoneDisplayOVDto>().ReverseMap();
            CreateMap<SmartphoneMemoryOV, SmartphoneMemoryOVDto>().ReverseMap();
            CreateMap<SmartphoneCameraOV, SmartphoneCameraOVDto>().ReverseMap();
            CreateMap<SmartphonePlatformOV, SmartphonePlatformOVDto>().ReverseMap();
            CreateMap<SmartphoneBatteryOV, SmartphoneBatteryOVDto>().ReverseMap();
            CreateMap<SmartphoneDimensionsOV, SmartphoneDimensionsOVDto>().ReverseMap();
        }
    }
}
