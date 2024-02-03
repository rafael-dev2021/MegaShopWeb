using Application.Mappings.Entities;
using Application.Mappings.Entities.CartMapping;
using Application.Mappings.Entities.Deliveries;
using Application.Mappings.Entities.DomainProduct;
using Application.Mappings.Entities.OrderMapping;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.EntitiesDtos;

public static class ApplicationMappingProfileDependecyInjection
{
    public static IServiceCollection AddProductMappingProfileDependecyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToMappingProductProfile));
        services.AddAutoMapper(typeof(DomainEntitiesToMappingProfile));
        services.AddAutoMapper(typeof(DomainOdersToMappingProfile));
        services.AddAutoMapper(typeof(DomainShoppingCartToMappingProfile));
        services.AddAutoMapper(typeof(DomainDeliveryToMappingProfile));
        return services;
    }
}
