using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private DishContext _context;

    public HomeController(ILogger<HomeController> logger, DishContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }

    [HttpGet("new")]
    public IActionResult NewDish()
    {
        return View("NewDish");
    }

    [HttpPost("create")]
    public IActionResult CreateDish(Dish dish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewDish");
        }
    }

    [HttpGet("dish/{id}")]
    public IActionResult ShowDish(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);
        return View(OneDish);
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
