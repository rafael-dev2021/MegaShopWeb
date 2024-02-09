using Application.Dtos.OrderDtos;
using AutoMapper;
using Domain.Entities.Orders;

namespace Application.Mappings.Entities.OrderMapping;

public class DomainOdersToMappingProfile : Profile
{
    public DomainOdersToMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
            .ReverseMap();

        CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ReverseMap();
    }
}
