using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        Friend Max = new Friend()
        {
            FirstName = "Max",
            LastName = "R",
            Location = "Miami",
            Age = 33
        };
        return View(Max);
    }

    [HttpPost("register")]
    public RedirectResult RegisterWizard(HogwartsStudent student) 
    {
        Console.WriteLine($"{student.Name} {student.House} {student.CurrentYear}");
        return Redirect("/");
    }

    [HttpGet("yerawizard")]
    public IActionResult WizardForm()
    {
        return View("WizardForm");
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
