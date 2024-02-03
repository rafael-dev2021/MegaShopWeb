using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Infra_Ioc;

public static class EnUSCultureInfoDI
{
    public static IServiceCollection AddEnUSCultureInfoDI(this IServiceCollection services)
    {
        services.AddLocalization(opt => opt.ResourcesPath = "Resources");
        var cultureInfo = new CultureInfo("en-US");
        cultureInfo.NumberFormat.CurrencySymbol = "$";
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        var supportedCultures = new[]
        {
            cultureInfo
        };

        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };
        return services;
    }
}
