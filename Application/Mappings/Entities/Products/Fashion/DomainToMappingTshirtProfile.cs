using Application.CQRS.Command.Products.Fashion.Tshirts;
using Application.Dtos.ProductsDto.Fashion.Tshirts;
using Application.Dtos.ProductsDto.Fashion.Tshirts.Valuables;
using AutoMapper;
using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Fashion.Tshirts.Valuables;

namespace Application.Mappings.Entities.Products.Fashion;

public class DomainToMappingTshirtProfile : Profile
{
    public DomainToMappingTshirtProfile()
    {
        CreateMap<Tshirt, TshirtDto>().ReverseMap();
        CreateMap<TshirtDto, CreateTshirtCommand>();
        CreateMap<TshirtDto, UpdateTshirtCommand>();
        CreateMap<TshirtOtherFeaturesOV, TshirtOtherFeaturesOVDto>().ReverseMap();
        CreateMap<TshirtMainFeaturesOV, TshirtMainFeaturesOVDto>().ReverseMap();
    }
}
