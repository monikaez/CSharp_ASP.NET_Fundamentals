using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;
using TextSplitterApp.ViewModels;

namespace TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index(TextSplitViewModel textSplitViewModel)
        {
            return View(textSplitViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextSplitViewModel textSplitViewModel)
        {
            if (String.IsNullOrWhiteSpace(textSplitViewModel.TextToSplit))
            {
                return this.RedirectToAction("Index", new TextSplitViewModel()
                {
                    TextToSplit = string.Empty,
                    SplitText = string.Empty
                });
            }
            string[] words = textSplitViewModel.TextToSplit
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string splitText = String.Join(Environment.NewLine, words);

            textSplitViewModel.SplitText = splitText;
            return this.RedirectToAction("Index", textSplitViewModel);
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
}