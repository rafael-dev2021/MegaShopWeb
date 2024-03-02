using Infra_Ioc.Application.EntitiesDtos;
using Infra_Ioc.Application.ProductsDtoDI.FashionDtoDI;
using Infra_Ioc.Application.ProductsDtoDI.TechnologyDtoDI;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public static class ApplicationInfrastructureModule
{
    public static IServiceCollection AddDApplicationInfrastructureModule(this IServiceCollection services)
    {
        services
               .AddBusinessRulesDependecyInjection()
               .AddEntitiesServicesDependecyInjection()
               .AddProductMappingProfileDependecyInjection()
               .AddFashionDtoAndMapperDependecyInjection()
               .AddTechnologyDtoAndMapperDependecyInjection();
        return services;
    }
}
