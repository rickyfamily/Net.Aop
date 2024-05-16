using Net.Aop.Client.Models;
using Net.Aop.Client.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Net.Aop.Client.Controllers
{
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [ServiceFilter(typeof(CustomActionWithParamFilterAttribute))]
        public IActionResult ActionWithParam()
        {
            Console.WriteLine($"Demo ActionWithParam excuted");
            return View();
        }

        [CustomActionFilter]
        [CustomResultFilter]
        public IActionResult Result()
        {
            Console.WriteLine($"Demo Result excuted");
            return Json(new { id = "1", name = "demo" }); 
        }

        [CustomAuthorizationFilter]
        public IActionResult Authorization()
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