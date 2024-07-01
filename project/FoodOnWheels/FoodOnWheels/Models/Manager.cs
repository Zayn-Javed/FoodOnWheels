using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOnWheels.Models
{
    public class Manager
    {
        public string Name { get; set; }    
        [Key]
        [DisplayName("User Name")]
        public string UserName { get; set; } 
        public string Password { get; set; }
        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }
        [DisplayName("Restaurant Location")]
        public string RestaurantLocation { get; set; }
        public List<SubMenu> subMenus { get; set; }
        public List<Order> orders { get; set; }
        public List<Review> review { get; set; }

    }
}
