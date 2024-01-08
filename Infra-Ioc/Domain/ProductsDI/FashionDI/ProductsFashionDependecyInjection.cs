using Domain.Entities.Interfaces.Products.Fashion;
using Infra_Data.Repositories.EntitiesRepositories.ProductsRepository.Fashion;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Domain.ProductsDI.FashionDI;

public static class ProductsFashionDependecyInjection
{
    public static IServiceCollection AddProductsFashionDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IShoesRepository, ShoesRepository>();
        services.AddScoped<ITshirtRepository, TshirtRepository>();

        return services;
    }
}
