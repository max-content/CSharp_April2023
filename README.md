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

### New MVC Project
1. Instead of new web or new console we're going to create a new mvc project with `dotnet new mvc --no-https -o ProjectName`
2. Create our model: 
```cs
#pragma warning disable CS8618
namespace FirstMVC.Models;


public class Friend 
{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Location {get;set;}
    public int Age {get;set;}
}
```
*This first line will disable to warning that vs code gives us that these strings are Not-Nullable properties or you can write the property like this: or `public string FirstName {get;set;} = null;`*

*To allow a string to be nullable say the field is optional you'd declare `public string? Location {get;set;}`*

### View Models
at the top of a cshtml file we want to put `@model [datatype]` ie: `@model string` means we're expecting the controller to send the view model a string through the View object.


### Inside the cshtml files in the Views folders
We will inherit the layout so the top of our code just has to have 
```cs
@{
    ViewData["Title"] = "Home Page";
}
```
and then change the title string. This will change the title of the webpage. Then we can just start with our div tag and write our code.

### Session
Start by adding this block of code to the Program.cs file
```
builder.Services.AddHttpContextAccessor();  
builder.Services.AddSession();  

app.UseSession();
```

* controller example with int? (because in this case we may receive a null value we add the ?)
```
// To store an int in session we use ".SetInt32"
HttpContext.Session.SetInt32("UserAge", 28);
// To retrieve an int from session we use ".GetInt32"
int? IntVariable = HttpContext.Session.GetInt32("UserAge");
```

* To Clear session `HttpContext.Session.Clear();`

* In cshtml file `@Context.Session.GetString("KeyName")` where keyname is the value of the key setup in the controller.