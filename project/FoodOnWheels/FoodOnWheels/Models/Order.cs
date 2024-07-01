using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOnWheels.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [DisplayName("Order Description")]
        public string Description { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public double Bill { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual FoodItems foodItem { get; set; }

    }
}
