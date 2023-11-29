using Application.Interfaces.Entities.TechnologyInterfaces;
using Application.Mappings.Products.Technology.Games;
using Application.Mappings.Products.Technology.Smartphones;
using Application.Services.Entities.Products.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class ApplicationToProductsTechnologyDependecyInjection
    {
        public static IServiceCollection AddProjectApplicationTechnologyDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISmartphoneDtoService, SmartphoneDtoService>();
            services.AddScoped<IGameDtoService, GameDtoService>();

            services.AddAutoMapper(typeof(DomainToMappingSmartphoneProfile));
            services.AddAutoMapper(typeof(DomainToMappingGameProfile));

            return services;
        }
    }
}
