using FoodOnWheels.Data;
using FoodOnWheels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FoodOnWheels.Controllers
{
    public class CustomerController : Controller
    {
        public AplicationDbContext _context;

        public CustomerController(AplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult CustomerMenu()
        { 

            return View();
        }
            // GET: ManagerController/Details/5
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer obj)
        {
            var list = new List<Customer>();
            list = _context.customer.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == obj.UserName && item.Password == obj.Password && item.Status==true)
                {
                    TempData["loginCustomer"] = obj.UserName;
                    isFound = true;

                }
                else
                {
                    ModelState.AddModelError("UserName", "Cannot be loged in! User Name or Password is incorrect");

                }
            }
            if (isFound)
            {

                return RedirectToAction("CustomerMenu");
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
        public ActionResult Create(Customer obj)
        {
            var list = new List<Customer>();
            list = _context.customer.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == obj.UserName)
                {
                    isFound = true;
                    ModelState.AddModelError("UserName","User Name is already taken! Please Select different User Name");
                }

            }
            if (ModelState.IsValid)
            {
                if (!isFound)
                {
                    obj.Status = true;
                    _context.customer.Add(obj);
                    var s = _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View();
        }

        public IActionResult UnblockIndex()
        {

            var data = _context.customer.FromSqlRaw("SELECT * from customer WHERE Status=0").ToList();

            //foreach (var item in data)
            //{
            //    if (item.status == true)
            //    {
            //        data.Remove(item);
            //    }
            //}
            return View(data);
        }

        public IActionResult Unblock(string? id)
        {
            var c = _context.customer.Where(x => x.UserName == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Unblock(Customer obj)
        {
            var c = _context.customer.Where(x => x.UserName == obj.UserName).FirstOrDefault();
            c.Status = true;
            _context.customer.Update(c);
            _context.SaveChanges();
            return RedirectToAction("UnblockIndex");
        }

        public IActionResult BlockIndex()
        {
            var data = _context.customer.FromSqlRaw("SELECT * from customer WHERE Status = 1").ToList();
            return View(data);
        }

        public IActionResult Block(string? id)
        {
            var c = _context.customer.Where(x => x.UserName == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Block(Rider obj)
        {
            //string s = obj.UserName;
            //_context.rid.FromSqlRaw("UPDATE rid SET Status= 0 WHERE UserName = {0}", s);
            //obj.status= false;
            //_context.rid.Update(obj);
            var c = _context.customer.Where(x => x.UserName == obj.UserName).FirstOrDefault();
            c.Status = false;
            _context.customer.Update(c);
            _context.SaveChanges();
            return RedirectToAction("BlockIndex");
        }
    }
}
