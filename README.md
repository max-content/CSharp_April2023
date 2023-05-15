# C# Project Setup Cheatsheet

### New Console Project
1. Create project folder
2. cd into project folder
3. run `dotnet new console`

OR

1. create new project running `dotnet new console -o ProjectName`
2. cd into ProjectName

4. / 3. `dotnet run`

### New Web Project
1. in your project folder `dotnet new web --no-https -o FirstWeb` 
   - this creates an app that doesn't have the support for https and the security features that comes with.
2. cd into new project folder
3. `dotnet run` or `dotnet watch run` (which will open the port for you)
*Note: The port is randomly selected between 5000 and 5300 you can find this in the terminal but also in Properties > launchSettings.json file*
4. Create folder structure
   - ProjectFolder
    | 
    - Controllers
      - HomeController.cs *the naming of this file is important*
    - Views
      - Home *This needs to match whatever you have as your Controller name. If it's HomeController then the folder is called Home if it's called UsersController then the folder Must be called Users.*
        - Index.cshtml
    - wwwroot *this is where we need to put all of our static files*
      - css
      - images

5. if using web creation method add this to your Program.cs file:
```cs
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
```
5. Create folder named Controllers
6. create HomeController:
```cs
using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers; //make sure you change this to the current project name!!

public class HomeController : Controller
{
    [HttpGet]
    [Route("test")] //the / before the route isn't necessary
    public string Test()
    {
        return "Hello World from HomeController!";

    }
    
    [HttpGet]
    [Route("")] //the / before the route isn't necessary
    public IActionResult Index()
    {
        return View();

    }
    
}
```