using FoodOnWheels.Data;
using FoodOnWheels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOnWheels.Controllers
{
    public class ReviewController : Controller
    {
        public AplicationDbContext _context;

        public ReviewController(AplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult SelectRestaurant()
        {
            var data = _context.Man.FromSqlRaw("SELECT * from Man").ToList();
            return View(data);
        }
        public IActionResult GiveReview(string? id)
        {
            TempData["selectedRestaurant"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult GiveReview(Review obj)
        {
            string s = TempData["selectedRestaurant"] as string;
            var manager = _context.Man.FromSqlRaw("SELECT * from Man WHERE UserName LIKE({0})", s).FirstOrDefault();
            TempData["selectedRestaurant"] = s;

            string s1 = TempData["loginCustomer"] as string;
            var customer = _context.customer.FromSqlRaw("SELECT * from customer WHERE UserName LIKE({0})", s1).FirstOrDefault();
            TempData["loginCustomer"] = s1;

            if(customer.review == null)
            {
                customer.review = new List<Review>();
            }
            if (manager.review == null)
            {
                manager.review = new List<Review>();
            }
            customer.review.Add(obj);
            manager.review.Add(obj);
            _context.Man.Update(manager);
            _context.SaveChanges();
            _context.customer.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("SelectRestaurant");
        }
        public IActionResult ShowReview()
        {
            string s = TempData["loginManager"] as string;
            var manager = _context.Man.FromSqlRaw("SELECT * from Man WHERE UserName LIKE({0})", s).FirstOrDefault();
            TempData["loginManager"] = s;
            var custData= _context.customer.FromSqlRaw("SELECT * from customer").ToList();
            var data = _context.Review.FromSqlRaw("SELECT * from Review").ToList();
            List<Customer> list = new List<Customer>();

            if (manager.review == null)
            {
                manager.review = new List<Review>();
            }
            foreach (var manrev in manager.review)
            {
                foreach (var custobj in custData)
                {
                    Customer customer= new Customer();
                    customer.FristName = custobj.FristName;
                    customer.review= new List<Review>();
                    if (custobj.review == null)
                    {
                        custobj.review = new List<Review>();
                    }
                    foreach (var custrev in custobj.review)
                    {
                        if (custrev.Id == manrev.Id)
                        {
                            customer.review.Add(custrev);
                        }
                    }
                    list.Add(customer);
                }
            }


            
            return View(list);
        }
    }
}
