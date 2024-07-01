using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOnWheels.Models
{
    public class SubMenu
    {
        [DisplayName("Menu Name")]
        public string MenuName { get; set; }
        [Key]
        public int MenuId { get; set; }
        public List<FoodItems> foodItems { get; set; }
    }
}
