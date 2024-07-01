using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodOnWheels.Data;
using FoodOnWheels.Models;

namespace FoodOnWheels.Controllers
{
    public class SubMenusController : Controller
    {
        private readonly AplicationDbContext _context;

        public SubMenusController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var data = _context.subMenus.ToList();
            string s = TempData["loginManager"] as string;
            var data = _context.subMenus.FromSqlRaw("SELECT * from SubMenus WHERE ManagerUserName like({0})", s).ToList();
            TempData["loginManager"] = s;
            return View(data);
        }
        public IActionResult AddFoodIndex()
        {
            //var data = _context.subMenus.ToList();
            string s = TempData["loginManager"] as string;
            var data = _context.subMenus.FromSqlRaw("SELECT * from SubMenus WHERE ManagerUserName like({0})", s).ToList();
            TempData["loginManager"] = s;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubMenu obj)
        {

            //  String s = "insert into anknc";
            // _context.subMenus.FromSqlRaw(s);
            string s = TempData["loginManager"] as string;
            var data = _context.Man.ToList();
            foreach (var item in data)
            {
                if (item.UserName==s)
                {
                    if (item.subMenus==null)
                    {
                        item.subMenus = new List<SubMenu>();
                        item.subMenus.Add(obj);
                    }
                    else
                    {
                        item.subMenus.Add(obj);
                    }
                    _context.Man.Update(item);
                }
            }
            
            //_context.subMenus.Add(obj);
            _context.SaveChanges();
            TempData["loginManager"] = s;
            return RedirectToAction("Index");
        }




        public IActionResult Edit(int? id)
        {
            var c = _context.subMenus.Where(x => x.MenuId == id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(SubMenu obj)
        {
            _context.subMenus.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            var c = _context.subMenus.Where(x => x.MenuId == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete(SubMenu obj)
        {
            _context.subMenus.Remove(_context.subMenus.Find(obj.MenuId));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
