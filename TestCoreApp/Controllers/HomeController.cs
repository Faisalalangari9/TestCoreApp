  using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;

namespace TestCoreApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;   //Depency injection 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //Action which goes to Views/Home/Index
        {
            return View();
        }

        public IActionResult Privacy() //Action which goes to Views/Home/Privacy
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] //Shared Action 
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
