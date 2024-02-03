using Domain.Entities.Cart.Interfaces;
using Domain.Entities.Interfaces;
using Domain.Entities.Orders.Interfaces;
using Domain.Entities.Payments.Interfaces;
using Domain.Interfaces.Reviews;
using Infra_Data.Repositories.EntitiesRepositories;
using Infra_Data.Repositories.EntitiesRepositories.CartRepositories;
using Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories;
using Infra_Data.Repositories.EntitiesRepositories.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Domain;

public static class EntitiesRepositoryDependecyInjection
{
    public static IServiceCollection AddEntitiesRepositoryDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IShoppingCartItemRepository, ShoppingCartRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepositories>();

        return services;
    }
}
