using Domain.Identity.Interfaces;
using Infra_Data.Context;
using Infra_Data.Identity;
using Infra_Ioc.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Identity;

public static class IdentityRulesDependecyInjection
{
    public static IServiceCollection AddIdentityRulesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
        services.AddScoped<ISeedUserRoleRepository, SeedUserRoleRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddDistributedMemoryCache();
        services.AddSession();
        services.AddMemoryCache();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(15);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
        });

        services.Configure<PasswordOptions>(options =>
        {
            options.RequireDigit = true;
            options.RequireLowercase = true;
            options.RequireUppercase = true;
            options.RequireNonAlphanumeric = true;
            options.RequiredLength = 8;
            options.RequiredUniqueChars = 6;
        });

        services.AddAuthorizationBuilder()
            .AddPolicy("Admin", policy =>
            {
                policy.RequireRole("Admin");
            });

        services.AddHttpsRedirection(options =>
        {
            options.HttpsPort = null;
        });

        services.AddHttpContextAccessor();
        services.AddMvc(options =>
        {
            options.Filters.Add(new SecurityHeadersAttribute());
        });

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(15);
        });

        services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-CSRF-TOKEN";
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.IsEssential = true;

            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });

        return services;
    }
}
