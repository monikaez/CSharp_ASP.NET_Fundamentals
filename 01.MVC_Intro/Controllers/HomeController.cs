

namespace WebApplicationASPNetDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Models;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //index HomePage
        public IActionResult Index()
        {
            ViewBag.Message = "Hello world from ViewBag!";
            ViewData["Messages"] = "Hello world from ViewData!";
            return View();
        }
        //page Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        //PageAbout
        public IActionResult About()
        {
            ViewBag.Message = "This is the first  ASP.NET Core MVC app.";
            return View();
        }

        //page Nimbers
       [HttpGet]
        public IActionResult Numbers()
        {
            return View();
        }
        //page Numbers 1 To N
        //onlyGet
        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewData["Count"] = -1;
            return this.View();
        }
        //+Post
        [HttpPost]
        public IActionResult NumbersToN(int count = -1)
        {
            ViewData["Count"] = count;
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}