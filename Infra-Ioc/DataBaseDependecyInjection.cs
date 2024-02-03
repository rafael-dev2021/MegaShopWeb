using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public static class DataBaseDependecyInjection
{
    public static IServiceCollection AddDataBaseDependecyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options =>
              {
                  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                      x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
              });
    }
}
