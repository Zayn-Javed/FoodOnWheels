using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOnWheels.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Review Description")]
        public string Description { get; set; }
    }
}
