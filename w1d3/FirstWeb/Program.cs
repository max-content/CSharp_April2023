var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

app.MapControllerRoute(
    name: "defualt",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
