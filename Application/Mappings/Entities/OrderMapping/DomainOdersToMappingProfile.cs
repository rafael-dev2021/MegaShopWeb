using Application.Dtos.OrderDtos;
using AutoMapper;
using Domain.Entities.Orders;

namespace Application.Mappings.Entities.OrderMapping;

public class DomainOdersToMappingProfile : Profile
{
    public DomainOdersToMappingProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
    }
}
