using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyMvc.Models;

namespace DojoSurveyMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult SubmitSurvey(User user) 
    {
        return RedirectToAction("Results", user);
    }

    [HttpGet("results")]
    public IActionResult Results(User user)
    {
        return View("Results", user);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
