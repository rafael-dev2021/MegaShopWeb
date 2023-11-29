using Application.Dtos.ProductsDto.Fashion.Tshirts;
using Application.Dtos.ProductsDto.Fashion.Tshirts.ObjectsValue;
using AutoMapper;
using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Fashion.Tshirts.ObjectsValue;

namespace Application.Mappings.Products.Fashion.Tshirts
{
    public class DomainToMappingTshirtProfile : Profile
    {
        public DomainToMappingTshirtProfile()
        {
            CreateMap<Tshirt, TshirtDto>().ReverseMap();
            CreateMap<TshirtOtherFeaturesOV, TshirtOtherFeaturesOVDto>().ReverseMap();
            CreateMap<TshirtMainFeaturesOV, TshirtMainFeaturesOVDto>().ReverseMap();
        }
    }
}
