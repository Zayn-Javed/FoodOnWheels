using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodOnWheels.Models
{
    public class Customer
    {
        [DisplayName("First Name")]
        public string FristName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Eamil { get; set; }
        [Key]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Phone Number is not valid")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public List<Order> orders { get; set; }
        public List<Review> review { get; set; }
    }
}
