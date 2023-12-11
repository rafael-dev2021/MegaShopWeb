using Domain.Entities.Interfaces.Products.Fashion;
using Infra_Data.Repositories.ProductsRepository.Fashion.ShoesRepository;
using Infra_Data.Repositories.ProductsRepository.Fashion.Tshirts;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class DomainToProductsFashionDI
    {
        public static IServiceCollection AddProjectDomainFashionDI(this IServiceCollection services)
        {
            services.AddScoped<IShoesRepository, ShoesRepository>();
            services.AddScoped<ITshirtRepository, TshirtRepository>();

       
            return services;
        }
    }
}
