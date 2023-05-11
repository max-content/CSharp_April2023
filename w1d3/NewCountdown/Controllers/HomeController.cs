using Microsoft.AspNetCore.Mvc;
namespace NewCountdown.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {

        DateTime Start = DateTime.Now;
        DateTime End = new DateTime(2023, 5, 11, 14, 26, 0); 
        TimeSpan Difference;

        Difference =  End - Start;
        Console.WriteLine("{0} - {1} = {2}", Start, End, Difference);

        ViewBag.Start = Start.ToString("ddd, MMM, dd, yyyy, hh:mm:ss");
        ViewBag.End = End.ToString("ddd, MMM, dd, yyyy, hh:mm:ss");
        ViewBag.Difference = Difference.ToString("h'h 'm'm 's's'");


        return View("Index");
    }

}