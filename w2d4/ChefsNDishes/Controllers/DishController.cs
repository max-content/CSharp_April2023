using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//~~~~~~~~~~~~~~~~~~~~~ Show All ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("dish/all")]
    public IActionResult ShowDishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Chef).ToList();
        return View(AllDishes);
    }

//~~~~~~~~~~~~~~~~~~~~~ Render New Dish Form ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("dish/new")]
    public IActionResult NewDish()
    {
        ViewBag.Chefs = _context.Chefs.ToList();
        return View("NewDish");
    }

//~~~~~~~~~~~~~~~~~~~~~~~ Create ~~~~~~~~~~~~~~~~~~~~~~~~~
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish dish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("OneDish");
        }
        else
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View("NewDish");
        }
    }

//~~~~~~~~~~~~~~~~~~~~~ Show One ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("dish/{DishId}")]
    public IActionResult OneDish(int DishId) {
        Dish? OneDish = _context.Dishes.Include(c => c.Chef).FirstOrDefault(dish => dish.DishId == DishId);
        return View(OneDish);
    }

//~~~~~~~~~~~~~~~~~~~~~ Edit ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpGet("dish/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        ViewBag.Chefs = _context.Chefs.ToList();

        Dish? DishToEdit = _context.Dishes.Include(c => c.Chef).FirstOrDefault(dish => dish.DishId == DishId);

        return View(DishToEdit);
    }

//~~~~~~~~~~~~~~~~~~~~~ Update ~~~~~~~~~~~~~~~~~~~~~~~
    [HttpPost("dish/{DishId}/update")]
    public IActionResult UpdateDish(Dish newDish, int DishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
        if(ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("OneDishes");
        }
        else 
        {
            return View("EditDish", OldDish);
        }
    }

}