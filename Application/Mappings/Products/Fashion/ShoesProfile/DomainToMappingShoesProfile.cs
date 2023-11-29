using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Dtos.ProductsDto.Fashion.Shoes.ObjectsValue;
using AutoMapper;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes.ObjectsValue;

namespace Application.Mappings.Products.Fashion.ShoesProfile
{
    public class DomainToMappingShoesProfile : Profile
    {
        public DomainToMappingShoesProfile()
        {
            CreateMap<Shoes, ShoesDto>().ReverseMap();
            CreateMap<ShoesDesignOV, ShoesDesignOVDto>().ReverseMap();
            CreateMap<ShoesGeneralFeaturesOV, ShoesGeneralFeaturesOVDto>().ReverseMap();
            CreateMap<ShoesMaterialsOV, ShoesMaterialsOVDto>().ReverseMap();
            CreateMap<ShoesSpecificationsOV, ShoesSpecificationsOVDto>().ReverseMap();
        }
    }
}
