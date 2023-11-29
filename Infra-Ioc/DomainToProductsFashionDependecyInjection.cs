using Domain.Entities.Interfaces.Products.Fashion;
using Infra_Data.Repositories.ProductsRepository.Fashion.ShoesRepository;
using Infra_Data.Repositories.ProductsRepository.Fashion.Tshirts;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class DomainToProductsFashionDependecyInjection
    {
        public static IServiceCollection AddProjectDomainFashionDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoesRepository, ShoesRepository>();
            services.AddScoped<ITshirtRepository, TshirtRepository>();

       
            return services;
        }
    }
}
