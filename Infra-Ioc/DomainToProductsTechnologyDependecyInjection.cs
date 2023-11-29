using Domain.Entities.Interfaces.Products.Technology;
using Infra_Data.Repositories.ProductsRepository.Technology.Games;
using Infra_Data.Repositories.ProductsRepository.Technology.Smartphones;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class DomainToProductsTechnologyDependecyInjection
    {
        public static IServiceCollection AddProjectDomainTechnologyDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ISmartphoneRepository, SmartphoneRepository>();
            return services;
        }
    }
}
