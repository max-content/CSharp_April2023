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

### Entity Framework
*installed globally with `dotnet tool install --global dotnet-ef` or can be added manually to each project with `dotnet ef`*

# Full CRUD Project Setup
- [x] Create a new project `dotnet new mvc --no-https -o ProjectName`
- [x] cd into new project
- [x] Add dependencies 
    ```
        dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
        dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
    ```
    can be check by looking at the ProjectName.csproj file 
    #### Models
- [x] create models
    ```
    #pragma warning disable CS8618
    using System.ComponentModel.DataAnnotations;
    namespace YourProjectName.Models;
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }
        public string Name { get; set; } 
        public int Height { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    ```
    *standard naming convention for model id is to name ModelNameID allows you to differenciate between different models you're working with.*
- [x] Add context file. The context file functions as the foundation of the relationship between the models and db.Naming these classes convention is to add Context at the end of the file name.
    ```
        #pragma warning disable CS8618
        // We can disable our warnings safely because we know the framework will assign non-null values 
        // when it constructs this class for us.
        using Microsoft.EntityFrameworkCore;
        namespace YourProjectName.Models;
        // the MyContext class represents a session with our MySQL database, allowing us to query for or save data
        // DbContext is a class that comes from EntityFramework, we want to inherit its features
        public class MyContext : DbContext 
        {   
            // This line will always be here. It is what constructs our context upon initialization  
            public MyContext(DbContextOptions options) : base(options) { }    
            // We need to create a new DbSet<Model> for every model in our project that is making a table
            // The name of our table in our database will be based on the name we provide here
            // This is where we provide a plural version of our model to fit table naming standards    
            public DbSet<Monster> Monsters { get; set; } 
        }
    ```
- [x] in the `aspsettings.json` file replace the mvc generated text with:
    ```
        {  
            "Logging": {    
                "LogLevel": {      
                    "Default": "Information",      
                    "Microsoft.AspNetCore": "Warning"    
                }  
            },
            "AllowedHosts": "*",    
            "ConnectionStrings":    
            {        
                "DefaultConnection": "Server=localhost;port=3306;userid=root;password=maxcontent;database=monsterdb;"    //<-- CHANGE DB NAME HERE 
            }
        }
    ```
    the section added is the ConnectionStrings this adds our database to our project.
- [x] Change the `Program.cs` file to:
    ```
        using Microsoft.EntityFrameworkCore;
        // You will need access to your models for your context file
        using ProjectName.Models;
        // Builder code from before
        var builder = WebApplication.CreateBuilder(args);
        // Create a variable to hold your connection string
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Make sure this is BEFORE var app = builder.Build()!!
        builder.Services.AddDbContext<MyContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    ```
- [x] Add migrations in the command line: `dotnet ef migrations add FirstMigration` as you need to migrate continue using the same naming convention ... SecondMigration, ThirdMigration. You can only use a name once per project.
- [x] Update db: `dotnet ef database update`
if there are errors we can troubleshoot by running `dotnet ef migrations add FirstMigration -v` in the command prompt.

#### Controller
- [x] add to controller:
    ``` 
        using System.Diagnostics;
        using Microsoft.AspNetCore.Mvc;
        using YourProjectName.Models;

        namespace YourProjectName.Controllers;
        
        public class HomeController : Controller
        {    
            private readonly ILogger<HomeController> _logger;
            private MyContext _context;         
           
            public HomeController(ILogger<HomeController> logger, MyContext context)    
            {        
                _logger = logger;
                _context = context;    
            } 

            [HttpGet("")]    
            public IActionResult Index()    
            {     
                // Now any time we want to access our database we use _context   
                List<Monster> AllMonsters = _context.Monsters.ToList();
                return View();    
            } 
        }
    ```
- [x] Create
    ```
        [HttpPost("monsters/create")]
        public IActionResult CreateMonster(Monster newMon)
        {    
            if(ModelState.IsValid)
            {
                // We can take the Monster object created from a form submission
                // and pass the object through the .Add() method  
                // Remember that _context is our database  
                _context.Add(newMon);    
                // OR _context.Monsters.Add(newMon); if we want to specify the table
                // EF Core will be able to figure out which table you meant based on the model  
                // VERY IMPORTANT: save your changes at the end! 
                _context.SaveChanges();
                return RedirectToAction("SomeAction");
            } else {
                // Handle unsuccessful validations
            }
        }
    ```
- [x] View All
    ```
        [HttpGet("")]
        public IActionResult Index()
        {
            // Get all Monsters
            ViewBag.AllMonsters = _context.Monsters.ToList();             
            
            // Get Monsters with the Name "Mike"
            ViewBag.AllMikes = _context.Monsters.Where(n => n.Name == "Mike");     	
            
            // Get the 5 most recently added Monsters        
            ViewBag.MostRecent = _context.Monsters.OrderByDescending(u => u.CreatedAt).Take(5).ToList(); 	
            
            // Get one Monster who has a certain description
            ViewBag.MatchedDesc = _context.Monsters.FirstOrDefault(u => u.Description == "Super scary");

            return View();
        }
    ```
- [x] View One
    ```
    [HttpGet("monsters/{id}")]    
    public IActionResult ShowMonster(int id)    
    {
        Monster? OneMonster = _context.Monsters.FirstOrDefault(a => a.MonsterId == id);            
        return View(OneMonster);  
    }
    ```
- [ ] Update
    ```
    [HttpGet("monsters/{MonsterId}/edit")]
    public IActionResult EditMonster(int MonsterId)
    {
        Monster? MonsterToEdit = _context.Monsters.FirstOrDefault(i => i.MonsterId == MonsterId);
        // Tip: it would be good to add a check here to ensure what you are grabbing will not return a null item
        return View(MonsterToEdit);
    }
    ```
*So long as your form still has all the asp-for attributes and @model Monster, it will auto-populate the fields!*

##### Processing Update:
    ```
        [HttpPost("monsters/{MonsterId}/update")]
        public IActionResult UpdateMonster(Monster newMon, int MonsterId)
        {
            Monster? OldMonster = _context.Monsters.FirstOrDefault(i => i.MonsterId == MonsterId);
            if(ModelState.IsValid)
            {
                OldMonster.Name = newMon.Name;
                OldMonster.Height = newMon.Height;
                OldMonster.Description = newMon.Description;
                OldMonster.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else 
            {
                return View("EditMonster", OldMonster);
            }
        }
    ```
Handling Post:
- in cshtml file:
    ```
    <form asp-action="UpdateMonster" asp-controller="Home" asp-route-MonsterId="@Model.MonsterId" method="post">
        @* the rest of our form *@
    </form>
    ```

##### Delete:
- [ ] Process Delete
    ```
    [HttpPost("monsters/{MonsterId}/destroy")]
    public IActionResult DestroyMonster(int MonsterId)
    {
        Monster? MonToDelete = _context.Monsters.SingleOrDefault(i => i.MonsterId == MonsterId);
        // Once again, it could be a good idea to verify the monster exists before deleting
        _context.Monsters.Remove(MonToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    ```
- [ ] Form Handling:
    ```
    <form asp-action="DestroyMonster" asp-controller="Home" asp-route-MonsterId="@Model.MonsterId" method="post">
        <input type="submit" value="Delete">
    </form>
    ```
