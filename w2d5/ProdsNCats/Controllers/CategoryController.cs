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
}