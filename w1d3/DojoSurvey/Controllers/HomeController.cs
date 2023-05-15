using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "Hello World from HomeController!";

    }
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();

    }
    
    [HttpPost("process")]
    public IActionResult Process(string Name, string City, string Language, string Comments)
    {

        Console.WriteLine($"{Name} {City} {Language} {Comments}");
        ViewBag.Name = Name;
        ViewBag.City = City;
        ViewBag.Language = Language;
        ViewBag.Comments = Comments;

        return View("Results");
    }
}