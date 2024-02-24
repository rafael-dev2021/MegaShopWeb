using Infra_Ioc;
using Infra_Ioc.Identity;
using WebUI.Middleware;

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
//var csp = "default-src 'self'; img-src 'self' data:; script-src 'self'; style-src 'self';";

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Append("Content-Security-Policy", csp);
//    await next();
//});

await SeedData.SeedUsersRoles(app);

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<LoggingMiddleware>();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "adminOrderProducts",
    pattern: "{area:exists}/{controller=AdminOrder}/{action=Index}/{id}/{*catchall}",
    defaults: new { action = "Index" },
    constraints: new { id = @"(.*)" } // Permitir qualquer caractere no ID
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();




