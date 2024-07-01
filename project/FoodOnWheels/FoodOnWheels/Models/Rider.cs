using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOnWheels.Models
{
    public class Rider
    {
        public string Name { get; set; }
        [Key]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        public List<Order> orders { get; set; }
    }
}
