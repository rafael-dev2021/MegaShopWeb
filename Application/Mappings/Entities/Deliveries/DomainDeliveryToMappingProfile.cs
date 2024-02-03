using Application.Dtos.Delivery;
using AutoMapper;
using Domain.Entities.Delivery;

namespace Application.Mappings.Entities.Deliveries;

public class DomainDeliveryToMappingProfile : Profile
{
    public DomainDeliveryToMappingProfile()
    {
        CreateMap<DeliveryAddress, DeliveryAddressDto>().ReverseMap();
        CreateMap<UserDelivery, UserDeliveryDto>().ReverseMap();
    }
}
