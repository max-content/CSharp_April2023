using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers;

public class HelloController : Controller
{
    // [HttpGet]
    // [Route("")] //the / before the route isn't necessary
    // public string Index()
    // {
    //     return "Hello World from HelloController!";

    // }

    //alternative to above syntax. - preceeding / is implied but the rest aren't. inside route strings variables are inside {}
    [HttpGet("greet/{name}")]
    public string Greet(string name)
    {
        return $"Hello {name}!";

    }
    
    [HttpGet]
    [Route("")] //the / before the route isn't necessary
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("info")]
    public ViewResult Info() 
    {
        return View("Info");
    }
    

}