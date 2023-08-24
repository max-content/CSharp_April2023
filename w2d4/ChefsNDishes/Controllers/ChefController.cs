using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
//~~~~~~~~~~~~~~~~~~~~~~~~~~ Constructor ~~~~~~~~~~~~~~~~~~~~~~~~~
    private readonly ILogger<ChefController> _logger;
    private MyContext _context;

//~~~~~~~~~~~~~~~~~~~~~~ Connect to MyContext ~~~~~~~~~~~~~~~~~~~~~
    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//~~~~~~~~~~~~~~~~~~~~~ Render Index (Show All) ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(d => d.AllDishes).ToList();

        return View(AllChefs);
    }

//~~~~~~~~~~~~~~~~~~~~~ Render New Chef Form ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("chef/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

//~~~~~~~~~~~~~~~~~~~~~~~ Create ~~~~~~~~~~~~~~~~~~~~~~~~~
[HttpPost("chef/create")]
public IActionResult CreateChef(Chef chef)
{
    if(ModelState.IsValid)
    {
        _context.Add(chef);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else 
    {
        return View("NewChef");
    }
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
