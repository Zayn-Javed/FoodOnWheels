using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOnWheels.Models
{
    public class FoodItems
    {
        [Key]
        public int ItemId { get; set; }
        [DisplayName("Food Name")]
        public string ItemName { get; set; }
        public double Price { get; set; }

    }
}
