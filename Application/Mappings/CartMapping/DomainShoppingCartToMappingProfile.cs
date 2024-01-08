using Application.Dtos.CartDto;
using AutoMapper;
using Domain.Entities.Cart;

namespace Application.Mappings.CartMapping;

public class DomainShoppingCartToMappingProfile : Profile
{
    public DomainShoppingCartToMappingProfile()
    {
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
    }
}
