using Domain.Identity.Interfaces;
using Infra_Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataBaseDependecyInjection(builder.Configuration);
//domain
builder.Services.AddProjectDomainDependecyInjection();
builder.Services.AddProjectDomainTechnologyDI();
builder.Services.AddProjectDomainFashionDI();
//Identity
builder.Services.AddIdentityRulesDependecyInjection();
//application
builder.Services.AddApplicationFashionDI();
builder.Services.AddApplicationTechnologyDI();
builder.Services.AddProjectApplicationDependecyInjection();
//Mappings
builder.Services.AddDomainEntitiesToApplicationMappingProfile();
//CultureInfo
builder.Services.AddEnUSCultureInfoDI();

builder.Services.AddSession();
builder.Services.AddMemoryCache();

var app = builder.Build();


//var csp = "default-src 'self'; img-src 'self' data:; script-src 'self'; style-src 'self';";


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

await SeedUsersRoles(app);

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("Content-Security-Policy", csp);
//    await next();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.Run();

async Task SeedUsersRoles(IApplicationBuilder builder)
{
    var scope = builder.ApplicationServices.CreateScope();
    var result = scope.ServiceProvider.GetService<ISeedUserRoleRepository>();

    await result.SeedRoleAsync();
    await result.SeedUserAsync();
}