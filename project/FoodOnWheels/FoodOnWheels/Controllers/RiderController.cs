using FoodOnWheels.Data;
using FoodOnWheels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOnWheels.Controllers
{
    public class RiderController : Controller
    {
        public AplicationDbContext _context;

        public RiderController(AplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult RiderMenu()
        {

            return View();
        }
        // GET: ManagerController/Details/5
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Rider obj)
        {
            var list = new List<Rider>();
            list = _context.rid.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == obj.UserName && item.Password == obj.Password && item.status==true)
                {
                    isFound = true;
                    TempData["loginRider"] = obj.UserName;
                }
                else
                {
                    ModelState.AddModelError("UserName", "Cannot be loged in! User Name or Password is incorrect");

                }
            }
            if (isFound)
            {

                return RedirectToAction("RiderMenu");
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
        public ActionResult Create(Rider obj)
        {
            var list = new List<Rider>();
            list = _context.rid.ToList();
            bool isFound = false;
            foreach (var item in list)
            {
                if (item.UserName == obj.UserName)
                {
                    isFound = true;
                    ModelState.AddModelError("UserName", "User Name is already taken! Please Select different User Name");

                }

            }
            if (!isFound)
            {
               // string s= "inster into manager(name, password, username) value()"
                obj.status = true;
                _context.rid.Add(obj);
                var s = _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult UnblockIndex()
        {

            var data = _context.rid.FromSqlRaw("SELECT * from rid WHERE Status=0").ToList();
            
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
            var c = _context.rid.Where(x => x.UserName == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Unblock(Rider obj)
        {
            var c = _context.rid.Where(x => x.UserName == obj.UserName).FirstOrDefault();
            c.status = true;
            _context.rid.Update(c);
            _context.SaveChanges();
            return RedirectToAction("UnblockIndex");
        }

        public IActionResult BlockIndex()
        {
            var data = _context.rid.FromSqlRaw("SELECT * from rid WHERE Status = 1").ToList();
            return View(data);
        }

        public IActionResult Block(string? id)
        {
            var c = _context.rid.Where(x => x.UserName == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Block(Rider obj)
        {
            //string s = obj.UserName;
            //_context.rid.FromSqlRaw("UPDATE rid SET Status= 0 WHERE UserName = {0}", s);
            //obj.status= false;
            //_context.rid.Update(obj);
            var c = _context.rid.Where(x => x.UserName == obj.UserName).FirstOrDefault();
            c.status = false;
            _context.rid.Update(c);
            _context.SaveChanges();
            return RedirectToAction("BlockIndex");
        }
    }
}
