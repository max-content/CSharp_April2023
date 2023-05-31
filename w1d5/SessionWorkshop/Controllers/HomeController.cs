using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("Counter", 22);
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string firstName)
    {
        if(firstName !=null)
        {
            HttpContext.Session.SetString("FirstName",firstName);
            return RedirectToAction("Dashboard");

        }
        return RedirectToAction("Index");
    }


    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        string? Name = HttpContext.Session.GetString("FirstName");
        if(Name == null)
        {
            RedirectToAction("Index");
        }
        return View("Dashboard");
    }

    [HttpPost("process/count")]
    public IActionResult Increment(string countVar)
    {
        Console.WriteLine(countVar);
        int? CurrentCount = HttpContext.Session.GetInt32("Counter");
        //if value == 1, 2, -1, random
        if(countVar == "1")
        {
            if(CurrentCount != null) HttpContext.Session.SetInt32("Counter", (int) CurrentCount + 1);
        } 
        else if(countVar == "2")
        {
            if(CurrentCount != null) HttpContext.Session.SetInt32("Counter", (int) CurrentCount + 2);
        }
        else if(countVar == "-1")
        {
            if(CurrentCount != null) HttpContext.Session.SetInt32("Counter", (int) CurrentCount - 1);
        }
        else
        {
            Random RandAlThor = new Random(); //random declaration 
            int DragonReborn = RandAlThor.Next(10,25); //random instance
            if(CurrentCount != null) HttpContext.Session.SetInt32("Counter", (int) CurrentCount + DragonReborn);
            Console.WriteLine(DragonReborn);
        }

        return RedirectToAction("Dashboard");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
