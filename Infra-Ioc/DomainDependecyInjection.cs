using Domain.Entities.Interfaces;
using Domain.Entities.Payments.Interfaces;
using Domain.Interfaces.Reviews;
using Infra_Data.Repositories.PaymentsRepositories;
using Infra_Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc
{
    public static class DomainDependecyInjection
    {
        public static IServiceCollection AddProjectDomainDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();


            //services.AddScoped<ISmartTvRepository, SmartTvRepository>();
            //services.AddScoped<IShoppingCartItemRepository, ShoppingCartRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IPaymentRepository, PaymentRepository>();
            return services;
        }
    }
}
