using Application.Dtos;
using Application.Dtos.PaymentsDto;
using Application.Dtos.Reviews;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Payments;
using Domain.Entities.Reviews;

namespace Application.Mappings.Entities;

public class DomainEntitiesToMappingProfile : Profile
{
    public DomainEntitiesToMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Card, CardDto>().ReverseMap();
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<CreditCard, CreditCardDto>().ReverseMap();
        CreateMap<DebitCard, DebitCardDto>().ReverseMap();
        CreateMap<PaymentMethod, PaymentMethodDto> ().ReverseMap();
        CreateMap<CategoryWithProductCount, CategoryWithProductCountDto>().ReverseMap();
    }
}
