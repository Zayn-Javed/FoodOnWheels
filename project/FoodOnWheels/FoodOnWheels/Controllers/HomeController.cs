using System.Diagnostics;
using FoodOnWheels.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOnWheels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AdminMenu()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Manager obj)
        {
            if (obj.UserName == "admin" && obj.Password == "12345")
            {
                return RedirectToAction("AdminMenu");
            }
            ModelState.AddModelError("UserName", "Cannot be loged in! User Name or Password is incorrect");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}