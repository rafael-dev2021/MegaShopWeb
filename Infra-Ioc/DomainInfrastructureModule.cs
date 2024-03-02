using Infra_Ioc.Domain;
using Infra_Ioc.Domain.ProductsDI.FashionDI;
using Infra_Ioc.Domain.ProductsDI.TechnologyDI;
using Infra_Ioc.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public static class DomainInfrastructureModule
{
    public static IServiceCollection AddDomainInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataBaseDependecyInjection(configuration)
            .AddEntitiesRepositoryDependecyInjection()
            .AddProductsTechnologyDependecyInjection()
            .AddProductsFashionDependecyInjection()
            .AddIdentityRulesDependecyInjection();

        return services;
    }
}
