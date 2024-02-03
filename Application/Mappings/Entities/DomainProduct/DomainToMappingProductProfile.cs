using Application.Dtos;
using Application.Dtos.Valuables.ProductsOV;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Valuables.ProductValuables;

namespace Application.Mappings.Entities.DomainProduct;

public class DomainToMappingProductProfile : Profile
{
    public DomainToMappingProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductDataOV, ProductDataOVDto>().ReverseMap();
        CreateMap<ProductFlagsOV, ProductFlagsOVDto>().ReverseMap();
        CreateMap<ProductPriceOV, ProductPriceOVDto>().ReverseMap();
        CreateMap<ProductSpecificationsOV, ProductSpecificationsOVDto>().ReverseMap();
        CreateMap<ProductWarrantyOV, ProductWarrantyOVDto>().ReverseMap();
    }
}
