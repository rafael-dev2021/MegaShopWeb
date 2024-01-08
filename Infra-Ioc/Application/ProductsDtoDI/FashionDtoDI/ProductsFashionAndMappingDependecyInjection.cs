using Application.Interfaces.Entities.Products.FashionInterfaces;
using Application.Mappings.Products.Fashion;
using Application.Services.Entities.Products.Fashion;
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
