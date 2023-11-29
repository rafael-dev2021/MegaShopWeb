using Application.Dtos;
using Application.Dtos.Reviews;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Reviews;

namespace Application.Mappings.Entities
{
    public class DomainToMappingProfile : Profile
    {
        public DomainToMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
        }

    }
}
