using Application.Interfaces.Entities;
using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.Interfaces;
using Application.Services.CountProductByPrice;
using Application.Services.CountProductByPrice.Interfaces;
using Application.Services.Discounts;
using Application.Services.Discounts.Interfaces;
using Application.Services.Entities;
using Application.Services.PriceIsHigherThan;
using Application.Services.PriceIsHigherThan.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infra_Ioc
{
    public static class ApplicationDependecyInjection
    {
        public static IServiceCollection AddProjectApplicationDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICountProductsByPriceService, CountProductsByPriceService>();
            services.AddScoped<IPriceIsHigherThanService, PriceIsHigherThanService>();
            services.AddScoped<ICalculateDiscountService, CalculateDiscountService>();
            services.AddScoped<IWeightedAverageResult, WeightedAverageCalculator>();

            services.AddScoped<IProductDtoService, ProductDtoService>();
            services.AddScoped<ICategoryDtoService, CategoryDtoService>();
            services.AddScoped<IReviewDtoService, ReviewDtoService>();

            var applicationAssembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), applicationAssembly);
            });

            return services;
        }
    }
}
