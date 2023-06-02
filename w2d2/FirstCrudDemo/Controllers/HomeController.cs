using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstCrudDemo.Models;

namespace FirstCrudDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MonsterContext _context; //This is new
    public HomeController(ILogger<HomeController> logger, MonsterContext context) //this has been changed
    {
        _logger = logger;
        _context = context; // this is new too
    }

    [HttpGet("")]
    public IActionResult Index()
    {
         // Get all Monsters
        ViewBag.AllMonsters = _context.Monsters.ToList();             
        
        // Get Monsters with the Name "Mike"
        ViewBag.AllMikes = _context.Monsters.Where(n => n.Name == "Mike");     	
        
        // Get the 5 most recently added Monsters        
        ViewBag.MostRecent = _context.Monsters.OrderByDescending(u => u.CreatedAt).Take(5).ToList(); 	
        
        // Get one Monster who has a certain description
        ViewBag.MatchedDesc = _context.Monsters.FirstOrDefault(u => u.Description == "Super scary");

        return View();
    }

[HttpPost("monsters/create")]
public IActionResult CreateMonster(Monster newMon)
{    
    if(ModelState.IsValid)
    {
        // We can take the Monster object created from a form submission
        // and pass the object through the .Add() method  
        // Remember that _context is our database  
        _context.Add(newMon);    
        // OR _context.Monsters.Add(newMon); if we want to specify the table
        // EF Core will be able to figure out which table you meant based on the model  
        // VERY IMPORTANT: save your changes at the end! 
        _context.SaveChanges();
        return RedirectToAction("SomeAction");
    } else {
        return RedirectToAction("Index");
    }
}

[HttpGet("monsters/{id}")]    
public IActionResult ShowMonster(int id)    
{
    Monster? OneMonster = _context.Monsters.FirstOrDefault(a => a.MonsterId == id);            
    return View(OneMonster);  
}

[HttpGet("monsters/{MonsterId}/edit")]
public IActionResult EditMonster(int MonsterId)
{
    Monster? MonsterToEdit = _context.Monsters.FirstOrDefault(i => i.MonsterId == MonsterId);
    // Tip: it would be good to add a check here to ensure what you are grabbing will not return a null item
    return View(MonsterToEdit);
}

// 1. Trigger a post request that contains the updated instance from our form and the ID of that instance
[HttpPost("monsters/{MonsterId}/update")]
public IActionResult UpdateMonster(Monster newMon, int MonsterId)
{
    // 2. Find the old version of the instance in your database
    Monster? OldMonster = _context.Monsters.FirstOrDefault(i => i.MonsterId == MonsterId);
    // 3. Verify that the new instance passes validations
    if(ModelState.IsValid)
    {
        // 4. Overwrite the old version with the new version
    	// Yes, this has to be done one attribute at a time
    	OldMonster.Name = newMon.Name;
        OldMonster.Height = newMon.Height;
        OldMonster.Description = newMon.Description;
    	// You updated it, so update the UpdatedAt field!
        OldMonster.UpdatedAt = DateTime.Now;
    	// 5. Save your changes
        _context.SaveChanges();
    	// 6. Redirect to an appropriate page
        return RedirectToAction("Index");
    } else {
    	// 3.5. If it does not pass validations, show error messages
    	// Be sure to pass the form back in so you don't lose your changes
        // It should be the old version so we can keep the ID
        return View("EditMonster", OldMonster);
    }
}

[HttpPost("monsters/{MonsterId}/destroy")]
public IActionResult DestroyMonster(int MonsterId)
{
    Monster? MonToDelete = _context.Monsters.SingleOrDefault(i => i.MonsterId == MonsterId);
    // Once again, it could be a good idea to verify the monster exists before deleting
    _context.Monsters.Remove(MonToDelete);
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
