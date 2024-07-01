using Microsoft.EntityFrameworkCore;
using FoodOnWheels.Models;

namespace FoodOnWheels.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Manager> Man { get; set; }
        public DbSet<Rider> rid { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<SubMenu> subMenus { get; set; }
        public DbSet<FoodItems> foodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodOnWheels.Models.Review>? Review { get; set; }

    }
}
