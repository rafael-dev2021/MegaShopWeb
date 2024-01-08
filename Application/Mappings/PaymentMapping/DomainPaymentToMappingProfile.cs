using Application.Dtos.PaymentsDto;
using AutoMapper;
using Domain.Entities.Payments;

namespace Application.Mappings.PaymentMapping;

public class DomainPaymentToMappingProfile : Profile
{
    public DomainPaymentToMappingProfile()
    {
        CreateMap<Payment, PaymentDto>().ReverseMap();
    }
}
