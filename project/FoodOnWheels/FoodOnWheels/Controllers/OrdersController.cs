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
    public class OrdersController : Controller
    {
        private readonly AplicationDbContext _context;

        public OrdersController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult SelectRestaurant()
        {
            var data = _context.Man.FromSqlRaw("SELECT * from Man").ToList();
            return View(data);
        }

        public IActionResult SelectSubMenu(string? id)
        {
            if(id != null)
            {
                TempData["selectedRestaurant"]=id;
                var data = _context.subMenus.FromSqlRaw("SELECT * from subMenus WHERE ManagerUserName LIKE({0})", id).ToList();
                return View(data);
            }
            else
            {
                string s = TempData["selectedRestaurant"] as string;
                var data = _context.subMenus.FromSqlRaw("SELECT * from subMenus WHERE ManagerUserName LIKE({0})", s).ToList();
                TempData["selectedRestaurant"] = s;
                return View(data);
            }
            //return View();
            
        }
        public IActionResult SelectFood(int? id)
        {
            if (id == null)
            {
                string s1 = TempData["selectedMenu"] as string;
                int id1 = int.Parse(s1);
                var data1 = _context.foodItems.FromSqlRaw("SELECT * from foodItems WHERE SubMenuMenuId LIKE({0})", id1).ToList();
                TempData["selectedMenu"] = s1;
                return View(data1); 
            }
            else
            {
                string s = id.ToString();
                TempData["selectedMenu"] = s;
                var data = _context.foodItems.FromSqlRaw("SELECT * from foodItems WHERE SubMenuMenuId LIKE({0})", id).ToList();
                return View(data);
            }
            
        }
        public IActionResult Create(int? id)
        {
            string s = id.ToString();
            TempData["selectedItem"] = s;
            return View();

        }
        [HttpPost]
        public IActionResult Create(Order obj)
        {
            
            string s= TempData["selectedItem"] as string;
            int id= int.Parse(s);
            var data = _context.foodItems.FromSqlRaw("SELECT * from foodItems WHERE ItemId LIKE({0})", id).FirstOrDefault();
            string login = TempData["loginCustomer"] as string;
            var loginObj = _context.customer.FromSqlRaw("SELECT * from customer WHERE UserName LIKE({0})", login).FirstOrDefault();
            TempData["loginCustomer"] = login;

            string man = TempData["selectedRestaurant"] as string;
            var manObj = _context.Man.FromSqlRaw("SELECT * from Man WHERE UserName LIKE({0})", man).FirstOrDefault();
            TempData["selectedRestaurant"] = man;
            double total = data.Price * obj.Quantity;
            obj.Bill = total;
            if (manObj.orders == null)
            {
                manObj.orders = new List<Order>();
            }
             
            if (loginObj.orders==null)
            {
                loginObj.orders = new List<Order>();
                obj.foodItem = data;
                obj.Status = "placed";
                loginObj.orders.Add(obj);
            }
            else
            {
                obj.foodItem = data;
                obj.Status = "placed";
                loginObj.orders.Add(obj);
            }
            
            manObj.orders.Add(obj);
            _context.Man.Update(manObj);
            _context.SaveChanges();
            _context.customer.Update(loginObj);
            _context.SaveChanges();
            return RedirectToAction("SelectFood");
        }
        public IActionResult FulFilOrder()
        {
            string s = TempData["loginManager"] as string;
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE ManagerUserName LIKE({0}) and Status LIKE('placed')", s).ToList();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            //List<FoodItems> list = new List<FoodItems>();
            //foreach (var item in data)
            //{
            //    foreach (var item1 in dataFood)
            //    {
            //        if (item.ItemId == item1.ItemId)
            //        {
            //            list.Add(item1);
            //        }
            //    }
            //}
            //ViewData["tempOrder"] = data;
            //ViewData["temoFood"] = list;
            TempData["loginManager"] = s;
            return View(data);
        }
        
        public IActionResult FilOrder(int? id)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", id).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult FilOrder(Order obj)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", obj.OrderId).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            data.Status = "ReadyToDeliver";
            _context.Orders.Update(data);
            _context.SaveChanges();
            return RedirectToAction("FulFilOrder");
        }




        /// <summary>
        /// /////
        /// </summary>
        /// <returns></returns>




        public IActionResult DeliverOrder()
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE Status LIKE('ReadyToDeliver')").ToList();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            //List<FoodItems> list = new List<FoodItems>();
            //foreach (var item in data)
            //{
            //    foreach (var item1 in dataFood)
            //    {
            //        if (item.ItemId == item1.ItemId)
            //        {
            //            list.Add(item1);
            //        }
            //    }
            //}
            //ViewData["tempOrder"] = data;
            //ViewData["temoFood"] = list;
            return View(data);
        }

        public IActionResult PickStatus(int? id)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", id).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult PickStatus(Order obj)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", obj.OrderId).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            data.Status = "PickedByRider";
            string s = TempData["loginRider"] as string;
            var loginObj = _context.rid.FromSqlRaw("SELECT * from rid WHERE UserName LIKE({0})", s).FirstOrDefault();
            TempData["loginRider"] = s;
            if (loginObj.orders == null)
            {
                loginObj.orders = new List<Order>();
            }
            loginObj.orders.Add(data);
            _context.rid.Update(loginObj);
            _context.SaveChanges();
            _context.Orders.Update(data);
            _context.SaveChanges();
            return RedirectToAction("DeliverOrder");
        }





        ///////////////////////////////
        ////
        ////
        ///

        public IActionResult DeliveredOrder()
        {
            string s = TempData["loginRider"] as string;
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE RiderUserName LIKE({0}) and Status LIKE('PickedByRider')", s).ToList();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            TempData["loginRider"] = s;
            //List<FoodItems> list = new List<FoodItems>();
            //foreach (var item in data)
            //{
            //    foreach (var item1 in dataFood)
            //    {
            //        if (item.ItemId == item1.ItemId)
            //        {
            //            list.Add(item1);
            //        }
            //    }
            //}
            //ViewData["tempOrder"] = data;
            //ViewData["temoFood"] = list;
            return View(data);
        }

        public IActionResult DeliverStatus(int? id)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", id).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult DeliverStatus(Order obj)
        {
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE orderId LIKE({0})", obj.OrderId).FirstOrDefault();
            var dataFood = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            data.Status = "Delivered";
            _context.Orders.Update(data);
            _context.SaveChanges();
            return RedirectToAction("DeliveredOrder");
        }

        public IActionResult CheckOrderStatus()
        {
            string login = TempData["loginCustomer"] as string;
            var cust = _context.customer.FromSqlRaw("SELECT * from customer WHERE UserName LIKE({0})", login).FirstOrDefault();
            TempData["loginCustomer"] = login;
            var data = _context.Orders.FromSqlRaw("SELECT * from Orders WHERE Status NOT LIKE('Delivered')").ToList();
            var data1 = _context.foodItems.FromSqlRaw("SELECT * from foodItems").ToList();
            //if(cust.orders == null)
            //{
            //    cust.orders = new List<Order>();
            //}
            //foreach(var item in data)
            //{
            //    if ()
            //    {

            //    }
            //}
            if (cust.orders==null)
            {
                cust.orders = new List<Order>();

            }
            return View(cust.orders);
        }
    }
}
