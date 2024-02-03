using Application.Services.Entities;
using Application.Services.Entities.CartDtoServices;
using Application.Services.Entities.CartDtoServices.Interfaces;
using Application.Services.Entities.Interfaces;
using Application.Services.Entities.OrderDtoServices;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infra_Ioc.Application.EntitiesDtos;

public static class EntitiesServicesDependecyInjection
{
    public static IServiceCollection AddEntitiesServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProductDtoService, ProductDtoService>();
        services.AddScoped<ICategoryDtoService, CategoryDtoService>();
        services.AddScoped<IReviewDtoService, ReviewDtoService>();
        services.AddScoped<IOrderDtoService, OrderDtoService>();
        services.AddScoped<IShoppingCartItemDtoService, ShoppingCartItemDtoService>();

        var applicationAssembly = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), applicationAssembly);
        });

        return services;
    }
}
