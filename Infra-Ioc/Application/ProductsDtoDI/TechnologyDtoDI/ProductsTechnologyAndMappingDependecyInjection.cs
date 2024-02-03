using Application.Mappings.Entities.Products.Technology;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using Application.Services.Entities.Products.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.ProductsDtoDI.TechnologyDtoDI;

public static class ProductsTechnologyAndMappingDependecyInjection
{
    public static IServiceCollection AddTechnologyDtoAndMapperDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ISmartphoneDtoService, SmartphoneDtoService>();
        services.AddScoped<IGameDtoService, GameDtoService>();

        services.AddAutoMapper(typeof(DomainToMappingSmartphoneProfile));
        services.AddAutoMapper(typeof(DomainToMappingGameProfile));

        return services;
    }
}
