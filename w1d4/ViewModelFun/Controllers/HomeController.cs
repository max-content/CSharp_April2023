using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        string Message = "Hello from the other side";
        return View("Index", Message);
    }

    [HttpGet("numbers")]
    public IActionResult Numbers() 
    {
        int[] numbersArr = new int[] {2,4,6,0,1};

        return View(numbersArr);
    }

    [HttpGet("user")]
    public IActionResult User()
    {
        User MyUser = new User()
        {
            FirstName = "Max",
            LastName = "Salzman",
            Email = "maxmerlyn1031@gmail.com",
            Password = "password"
        };
        return View("User", MyUser);
    }

    [HttpGet("users")]
    public IActionResult Users() 
    {   
        User UserOne = new User() 
        {
            FirstName = "Not a Max",
            LastName = "Salzman",
            Email = "maxmerlyn1031@gmail.com",
            Password = "password"
        };

        User UserTwo = new User() 
        {
            FirstName = "Max S.",
            LastName = "Salzman",
            Email = "maxmerlyn1031@gmail.com",
            Password = "password"
        };

        User UserThree = new User() 
        {
            FirstName = "Max R.",
            LastName = "Salzman",
            Email = "maxmerlyn1031@gmail.com",
            Password = "password"
        };

        List<User> ListOfUsers = new List<User>();
        ListOfUsers.Add(UserOne);
        ListOfUsers.Add(UserTwo);
        ListOfUsers.Add(UserThree);

        return View("Users", ListOfUsers);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
