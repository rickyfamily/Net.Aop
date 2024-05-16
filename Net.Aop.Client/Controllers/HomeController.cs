using Microsoft.AspNetCore.Mvc;
using Net.Aop.Client.Models;
using Net.Aop.Client.Utility;
using System.Diagnostics;

namespace Net.Aop.Client.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            //this._logger.LogInformation("This is home Index");
            Console.WriteLine($"Home Index excuted");
            return View();
        }

        public IActionResult Privacy()
        {
            //throw new Exception("HomeController Privacy");
            Console.WriteLine($"Home Privacy excuted");
            return View();
        }

        [CustomCacheResourceFilter]
        public IActionResult Resource()
        {
            Console.WriteLine($"Home Resource excuted");
            ViewBag.CacheTime = DateTime.Now;
            return View();
        }

        public IActionResult Exception()
        {
            Console.WriteLine($"Home Exception excuted");
            throw new Exception("HomeController Exception");
            return View();
        }

        public IActionResult ExceptionInView()
        {
            Console.WriteLine($"Home ExceptionInView excuted");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}