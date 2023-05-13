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
    public ViewResult Index()
    {
        return View();

    }
    
}