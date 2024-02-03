using Application.Mappings.Entities.Products.Fashion;
using Application.Services.Entities.Products.Fashion;
using Application.Services.Entities.Products.Interfaces.FashionInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.ProductsDtoDI.FashionDtoDI;

public static class ProductsFashionAndMappingDependecyInjection
{
    public static IServiceCollection AddFashionDtoAndMapperDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IShoesDtoService, ShoesDtoService>();
        services.AddScoped<ITshirtDtoService, TshirtDtoService>();

        services.AddAutoMapper(typeof(DomainToMappingShoesProfile));
        services.AddAutoMapper(typeof(DomainToMappingTshirtProfile));
        return services;
    }
}
