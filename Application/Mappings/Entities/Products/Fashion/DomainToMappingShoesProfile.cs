using Application.CQRS.Command.Products.Fashion.ProductShoes;
using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Dtos.ProductsDto.Fashion.Shoes.Valuables;
using AutoMapper;
using Domain.Entities.Products.Fashion.ProductShoes;

namespace Application.Mappings.Entities.Products.Fashion;

public class DomainToMappingShoesProfile : Profile
{
    public DomainToMappingShoesProfile()
    {
        CreateMap<Shoes, ShoesDto>().ReverseMap();
        CreateMap<ShoesDto, CreateShoesCommand>();
        CreateMap<ShoesDto, UpdateShoesCommand>();
        CreateMap<ShoesDesignOV, ShoesDesignOVDto>().ReverseMap();
        CreateMap<ShoesGeneralFeaturesOV, ShoesGeneralFeaturesOVDto>().ReverseMap();
        CreateMap<ShoesMaterialsOV, ShoesMaterialsOVDto>().ReverseMap();
        CreateMap<ShoesSpecificationsOV, ShoesSpecificationsOVDto>().ReverseMap();
    }
}
