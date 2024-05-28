using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Ro_VideoGameCatalogue.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Welcome(string name, int NumTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = NumTimes;
            return View();
        }

        public IActionResult Database(string name, int date = 1940, int review = 0)
        {
            if(date < 0 || review < 0)
            {
                Console.WriteLine("Invalid date");
                return View();
            }
            if (review > 5)
            {
                review = 5;
            }
            ViewData["Copy"] = "" + name + " was released during " + date;
            ViewData["Review"] = "You have given this a rating of " + review + " out of 5.";
            return View();
        }
        public string IndexStatement()
        {
            return "This is an index";
        }
        public IActionResult Index()
        {
            return View();
        }
        public string HelloWorld()
        {
            return "Hello World";
        }

        public string WelcomeFriend(string name, int age)
        {
            return HtmlEncoder.Default.Encode($"Welcome {name}. You are {age} years old");
        }

        public string VideoGameRating(string name, int rating, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"You've given {name} a rating of {rating} out of 5 stars. The ID for this is {ID}");
        }
        //public IActionResult Index()
       // {
        //    return View();
       // }
    }
}
