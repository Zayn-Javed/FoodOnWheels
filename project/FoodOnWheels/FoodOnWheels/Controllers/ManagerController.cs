using FoodOnWheels.Data;
using FoodOnWheels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOnWheels.Controllers
{
    public class ManagerController : Controller
    {
        public AplicationDbContext _context;

        public ManagerController(AplicationDbContext db)
        {
            _context = db;
        }

        public IActionResult ManagerMenu()
        {
            //var obj = TempData["loginManager"] as Manager;
            //var data = _context.foodItems.ToList();
            //var selected_data= new List<SubMenu>();

            return View();
        }

        // GET: ManagerController/Details/5
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Manager obj)
        {
            var list = new List<Manager>();
            list = _context.Man.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == obj.UserName && item.Password== obj.Password)
                {
                    isFound = true;
                    TempData ["loginManager"]= obj.UserName;
                }
                else
                {
                    ModelState.AddModelError("UserName", "Cannot be loged in! User Name or Password is incorrect");

                }
            }
            if (isFound)
            {
                
                return RedirectToAction("ManagerMenu");
            }

            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manager man)
        {
            var list= new List<Manager>();
            list= _context.Man.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == man.UserName)
                {
                    isFound = true;
                    ModelState.AddModelError("UserName", "User Name is already taken! Please Select different User Name");
                }

            }
            if (!isFound)
            {
                _context.Man.Add(man);
                var s = _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
