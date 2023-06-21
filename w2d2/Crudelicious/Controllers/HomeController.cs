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

    [HttpGet("dish/{id}/edit")]
    public IActionResult EditDish(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == id);
        return View("Edit", OneDish);
    }

    [HttpPost("dish/{DishId}/update")]
    public IActionResult UpdateDish(Dish newDish, int DishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);
        if(ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else 
        {
            return View("EditDish", OldDish);
        }
    }

    [HttpPost("dish/{DishId}/destroy")]
    public IActionResult DestroyDish(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
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
