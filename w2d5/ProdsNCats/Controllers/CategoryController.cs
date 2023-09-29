using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProdsNCats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProdsNCats.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private MyContext _context;

    public CategoryController(ILogger<CategoryController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/category")]
    public IActionResult CategoryIdx()
    {
        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllCategories = _context.Categories.Include(p => p.Associations).ThenInclude(c => c.Product).ToList()
        };
        return View(indexViewModel);
    }

    //~~~~~~~~~~~~~~~~~ Show All ~~~~~~~~~~~~~~~~~~
    [HttpGet("category/all")]
    public IActionResult ShowCategories()
    {
        Console.WriteLine("I AM HERE");

        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllCategories = _context.Categories.Include(p => p.Associations).ThenInclude(c => c.Product).ToList()
        };
        return View(indexViewModel);
    }


    //~~~~~~~~~~~~~~~ Render Form ~~~~~~~~~~~~~~~~
    [HttpGet("category/new")]
    public IActionResult NewCategory()
    {
        return View("NewCategory");
    }

    //~~~~~~~~~~~~~~~~~ Create ~~~~~~~~~~~~~~~~~~~
    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category category)
    {

        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllCategories = _context.Categories.Include(p => p.Associations).ThenInclude(c => c.Product).ToList()
        };

        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIdx");
        }
        else
        {

            return View("CategoryIdx", indexViewModel);
        }
    }

    //~~~~~~~~~~~~~~~~~ Show One ~~~~~~~~~~~~~~~~~~
    [HttpGet("category/{CategoryId}")]
    public IActionResult OneCategory(int CategoryId)
    {
        IndexViewModel indexViewModel = new IndexViewModel
        {
            Category = _context.Categories.Include(p => p.Associations).ThenInclude(c => c.Product).FirstOrDefault(p => p.CategoryId == CategoryId),

            //Getting all products including the associations then including the category where the association has a categoryID that matches the categoryId given and returns a list
            AllProducts = _context.Products.Include(p => p.Associations).ThenInclude(c => c.Category).Where(a => !a.Associations.Any(c => c.CategoryId == CategoryId)).ToList()
            // whenever a student gets this partially correct they put the != in the .Any statement instead of before .Any inside the LAMDA of the where.

        };

        return View(indexViewModel);
    }

    //~~~~~~~~~~~~ Add Association ~~~~~~~~~~~~~~~~
    [HttpPost("category/add/association")]
    public IActionResult AddCatAssociation(int productId, int categoryId)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
        }
        Console.WriteLine("I AM HERE");
        //Console.WriteLine(viewModelData.Association.CategoryId);

        Association association = new Association() { CategoryId = categoryId, ProductId = productId };

        _context.Add(association);
        _context.SaveChanges();
        return RedirectToAction("OneCategory", new { categoryId = categoryId });
    }
}