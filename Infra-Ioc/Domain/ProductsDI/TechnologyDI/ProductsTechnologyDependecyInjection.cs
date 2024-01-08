using Domain.Entities.Interfaces.Products.Technology;
using Infra_Data.Repositories.EntitiesRepositories.ProductsRepository.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Domain.ProductsDI.TechnologyDI;

public static class ProductsTechnologyDependecyInjection
{
    public static IServiceCollection AddProductsTechnologyDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<ISmartphoneRepository, SmartphoneRepository>();
        return services;
    }
}
