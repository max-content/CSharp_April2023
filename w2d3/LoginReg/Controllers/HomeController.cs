using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using LoginReg.Models;

namespace LoginReg.Controllers;

public class HomeController : Controller
{
//~~~~~~~~~~~~~~~~~~~~~~~~~~ Constructor ~~~~~~~~~~~~~~~~~~~~~~~~~
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

//~~~~~~~~~~~~~~~~~~~~~~ Connect to MyContext ~~~~~~~~~~~~~~~~~~~~~
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    } 

//~~~~~~~~~~~~~~~~~~~~~~~~~~ Render Index ~~~~~~~~~~~~~~~~~~~~~~~~~
    public IActionResult Index()
    {
        return View("Index");
    }

//~~~~~~~~~~~~~~~~~~~~~~~~~ Register User ~~~~~~~~~~~~~~~~~~~~~~~~~
    [HttpPost("users/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hashbrowns = new PasswordHasher<User>();
            newUser.Password = Hashbrowns.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        else {
            return Index();
        }
    }

//~~~~~~~~~~~~~~~~~~~ Login User ~~~~~~~~~~~~~~~~~~~~
    [HttpPost("users/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if(ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
            
            if(userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return Index();
            }

            PasswordHasher<LoginUser> hashbrowns = new PasswordHasher<LoginUser>();
            
            var result = hashbrowns.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);

            if(result == 0)
            {
                ModelState.AddModelError("Password", "Incorrect Password - please enter a valid password.");
                return Index();
            }
            
            //set UserId to Session
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            //return dashboard with user in session
            return RedirectToAction("Dashboard");
        }
        else 
        {
            return Index();
        }
    }

//~~~~~~~~~~~~~~~ Render Dashboard ~~~~~~~~~~~~~~~~~~
    [SessionCheck]
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        int? UserIdInSession = HttpContext.Session.GetInt32("UserId");
        // Console.WriteLine(UserIdInSession);
        
        User? UserInSession = _context.Users.FirstOrDefault(u => u.UserId == UserIdInSession);

        // Console.WriteLine(UserInSession.FirstName);

        return View("Dashboard", UserInSession);
    } 

//~~~~~~~~~~~~~~~ Logout ~~~~~~~~~~~~~~~~~~
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

//~~~~~~~~~~~~~~~ Error Handling ~~~~~~~~~~~~~~~~~~
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

//~~~~~~~~~~~~ Session Check Attribute ~~~~~~~~~~~~~~
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? UserId = context.HttpContext.Session.GetInt32("UserId");

        if(UserId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}

