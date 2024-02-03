using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.Interfaces;
using Application.Services.CountProductByPrice;
using Application.Services.CountProductByPrice.Interfaces;
using Application.Services.Discounts;
using Application.Services.Discounts.Interfaces;
using Application.Services.PriceIsHigherThan;
using Application.Services.PriceIsHigherThan.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.EntitiesDtos;

public static class BusinessRulesDependecyInjection
{
    public static IServiceCollection AddBusinessRulesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICountProductsByPriceService, CountProductsByPriceService>();
        services.AddScoped<IPriceIsHigherThanService, PriceIsHigherThanService>();
        services.AddScoped<ICalculateDiscountService, CalculateDiscountService>();
        services.AddScoped<IWeightedAverageResult, WeightedAverageCalculator>();

        return services;
    }
}
