using Microsoft.AspNetCore.Mvc;
using Net.Aop.Client.Models;
using Net.Aop.Service.Interface;
using System.Diagnostics;

namespace Net.Aop.Client.Controllers
{
    public class AopController : Controller
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IUserService _userService;

        public AopController(ILogger<DemoController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            Console.WriteLine($"Aop Index excuted");
            _userService.Login("demo", "123");            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}