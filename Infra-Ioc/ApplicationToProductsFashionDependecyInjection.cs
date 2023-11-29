using Application.Interfaces.Entities.Products.FashionInterfaces;
using Application.Mappings.Products.Fashion.ShoesProfile;
using Application.Mappings.Products.Fashion.Tshirts;
using Application.Services.Entities.Products.Fashion;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class ApplicationToProductsFashionDependecyInjection
    {
        public static IServiceCollection AddProjectApplicationFashionDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoesDtoService, ShoesDtoService>();
            services.AddScoped<ITshirtDtoService, TshirtDtoService>();

            services.AddAutoMapper(typeof(DomainToMappingShoesProfile));
            services.AddAutoMapper(typeof(DomainToMappingTshirtProfile));
            return services;
        }
    }
}
