using Application.CQRS.Command.Products.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Games.ObjectsValue;
using AutoMapper;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games.ObjectsValue;

namespace Application.Mappings.Products.Technology.Games
{
    public class DomainToMappingGameProfile : Profile
    {
        public DomainToMappingGameProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameDto, CreateGameCommand>();
            CreateMap<GameDto, UpdateGameCommand>();
            CreateMap<GameGeneralFeaturesOV, GameGeneralFeaturesOVDto>().ReverseMap();
            CreateMap<GameSpecificationsOV, GameSpecificationsOVDto>().ReverseMap();
            CreateMap<GameRequirementsOV, GameRequirementsOVDto>().ReverseMap();
        }
    }
}
