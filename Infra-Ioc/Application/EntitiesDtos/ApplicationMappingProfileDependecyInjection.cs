using Application.Mappings.CartMapping;
using Application.Mappings.Entities;
using Application.Mappings.Entities.DomainProduct;
using Application.Mappings.OrderMapping;
using Application.Mappings.PaymentMapping;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.EntitiesDtos;

public static class ApplicationMappingProfileDependecyInjection
{
    public static IServiceCollection AddProductMappingProfileDependecyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToMappingProductProfile));
        services.AddAutoMapper(typeof(DomainEntitiesToMappingProfile));
        services.AddAutoMapper(typeof(DomainOdersToMappingProfile));
        services.AddAutoMapper(typeof(DomainPaymentToMappingProfile));
        services.AddAutoMapper(typeof(DomainShoppingCartToMappingProfile));
        return services;
    }
}
