using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProdsNCats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProdsNCats.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private MyContext _context;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllProducts = _context.Products.Include(p => p.Associations).ThenInclude(c => c.Category).ToList()
        };
        return View(indexViewModel);
    }

    //~~~~~~~~~~~~~~~~~ Show All ~~~~~~~~~~~~~~~~~~
    [HttpGet("product/all")]
    public IActionResult ShowProducts()
    {
        Console.WriteLine("I AM HERE");

        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllProducts = _context.Products.Include(p => p.Associations).ThenInclude(c => c.Category).ToList()
        };
        return View(indexViewModel);
    }

    //~~~~~~~~~~~~~~~ Render Form ~~~~~~~~~~~~~~~~
    [HttpGet("product/new")]
    public IActionResult NewProduct()
    {
        return View("NewProduct");
    }

    //~~~~~~~~~~~~~~~~~ Create ~~~~~~~~~~~~~~~~~~~
    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product product)
    {

        IndexViewModel indexViewModel = new IndexViewModel
        {
            AllProducts = _context.Products.Include(p => p.Associations).ThenInclude(c => c.Category).ToList()
        };

        if (ModelState.IsValid)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {

            return View("Index", indexViewModel);
        }
    }

    //~~~~~~~~~~~~~~~~~ Show One ~~~~~~~~~~~~~~~~~~
    [HttpGet("product/{ProductId}")]
    public IActionResult OneProduct(int ProductId)
    {
        Product? OneProduct = _context.Products.Include(p => p.Associations).ThenInclude(c => c.Category).FirstOrDefault(p => p.ProductId == ProductId);
        return View(OneProduct);
    }

    //~~~~~~~~~~~~~~~ Render Edit ~~~~~~~~~~~~~~~~

    //~~~~~~~~~~~~~~~~~ Update ~~~~~~~~~~~~~~~~~~~

    //~~~~~~~~~~~~~~~~~ Delete ~~~~~~~~~~~~~~~~~~~

}