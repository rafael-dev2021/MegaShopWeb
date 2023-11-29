using Infra_Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataBaseDependecyInjection(builder.Configuration);
//domain
builder.Services.AddProjectDomainDependecyInjection();
builder.Services.AddProjectDomainTechnologyDependecyInjection();
builder.Services.AddProjectDomainFashionDependecyInjection();
//application
builder.Services.AddProjectApplicationFashionDependecyInjection();
builder.Services.AddProjectApplicationTechnologyDependecyInjection();
builder.Services.AddProjectApplicationDependecyInjection();
//Mappings
builder.Services.AddApplicationMappingsProfile();

builder.Services.AddSession();
builder.Services.AddMemoryCache();

var app = builder.Build();


//var csp = "default-src 'self'; img-src 'self' data:; script-src 'self'; style-src 'self';";


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


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

