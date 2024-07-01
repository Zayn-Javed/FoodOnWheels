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
    public class FoodItemsController : Controller
    {
        private readonly AplicationDbContext _context;

        public FoodItemsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodItems
        public IActionResult Index(int? id)
        {
            if (id==null)
            {
                string str = TempData["currMenu"] as string;
                int currId = int.Parse(str);
                var data1 = _context.foodItems.FromSqlRaw("SELECT * from foodItems WHERE SubMenuMenuId like({0})", currId).ToList();
                TempData["currMenu"] = str;
                return View(data1);
            }
            else
            {
                string s = id.ToString();
                TempData["currMenu"] = s;
                var data = _context.foodItems.FromSqlRaw("SELECT * from foodItems WHERE SubMenuMenuId like({0})", id).ToList();
                return View(data);
            }
            


            //var data = _context.foodItems.ToList();
            //return View(data);
        }
        public IActionResult Details(int? id)
        {
            var c = _context.foodItems.Where(x => x.ItemId == id).FirstOrDefault();
            return View(c);
        }
 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodItems obj)
        {

            //  String s = "insert into anknc";
            // _context.subMenus.FromSqlRaw(s);
            string s = TempData["currMenu"] as string;
            int currId= int.Parse(s);
            var data = _context.subMenus.FromSqlRaw("SELECT * from subMenus WHERE MenuId like({0})", currId).FirstOrDefault();
            TempData["currMenu"] = s;
            if (data.foodItems == null)
            {
                data.foodItems = new List<FoodItems>();
                data.foodItems.Add(obj);
            }
            else
            {
                data.foodItems.Add(obj);
            }
            _context.subMenus.Update(data);
            _context.SaveChanges();
            return RedirectToAction("Index",currId);
        }




        public IActionResult Edit(int? id)
        {
            var c = _context.foodItems.Where(x => x.ItemId == id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(FoodItems obj)
        {
            _context.foodItems.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            var c = _context.foodItems.Where(x => x.ItemId == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete(FoodItems obj)
        {
            _context.foodItems.Remove(_context.foodItems.Find(obj.ItemId));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
