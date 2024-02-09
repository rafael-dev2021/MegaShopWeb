using Infra_Ioc;
using Infra_Ioc.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDomainInfrastructureModule(builder.Configuration);
builder.Services.AddDApplicationInfrastructureModule();

builder.Services.AddEnUSCultureInfoDI();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

await SeedData.SeedUsersRoles(app);

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();









//var csp = "default-src 'self'; img-src 'self' data:; script-src 'self'; style-src 'self';";

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("Content-Security-Policy", csp);
//    await next();
//});