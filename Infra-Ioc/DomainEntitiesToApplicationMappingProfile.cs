using Application.Mappings.Entities;
using Application.Mappings.Entities.DomainProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class DomainEntitiesToApplicationMappingProfile
    {
        public static IServiceCollection AddApplicationMappingsProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToMappingProductProfile));
            services.AddAutoMapper(typeof(DomainToMappingProfile));
            return services;
        }
    }
}
