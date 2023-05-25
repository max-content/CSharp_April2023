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
        if(Comments == null)
        {
            Comments = "No Comment";
            Console.WriteLine($"{Name} {City} {Language} {Comments}");
        } else {
            Console.WriteLine($"{Name} {City} {Language} {Comments}");
        }

        return RedirectToAction("RenderResults", new {Name = Name, City = City, Language = Language, Comments = Comments});
    }

    [HttpGet("results")]
    public IActionResult RenderResults(string Name, string City, string Language, string Comments) 
    {
        ViewBag.Name = Name;
        ViewBag.City = City;
        ViewBag.Language = Language;
        ViewBag.Comments = Comments;

        return View("Results");
    }
    
    [HttpGet("back")]
    public RedirectResult GoBack()
    {
        return Redirect("/");
    }
}