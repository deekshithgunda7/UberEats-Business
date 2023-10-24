using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        [RegularExpression("[A-Za-z]+", ErrorMessage ="First Name must be letters only")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last Name")]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Last Name must be letters only")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter DOB")]
        [Remote("CheckAge", "Home", ErrorMessage = "You must be 18 years old.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please enter SSN")]
        [RegularExpression(@"^[0-9\-]+$", ErrorMessage = "SSN Must be numbers and dashes only.")]

        public string SSN { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(50, ErrorMessage ="max 50 charectors")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage ="Address must be alphanumeric")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Post Code")]
        [RegularExpression(@"^\d+-\d+$", ErrorMessage = "Post code Must be numbers and dashes only.")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [Remote("CheckEmail", "Home", ErrorMessage = "Email already exists.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter valid Phone Number")]
        [RegularExpression(@"^\d+[-.]*\d+[-.]*\d+$", ErrorMessage = "Phone Number Must be numbers and dashes and dots only.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Driving License Number")]
        [RegularExpression(@"^[a-zA-Z0-9]+-[a-zA-Z0-9]+$", ErrorMessage ="Driver license must be alphanumeric and dashes only")]
        public string DLNumber { get; set; }
        public int? StatusID { get; set; }
        public virtual Status? Status { get; set; }
        public int GetYears()
        {
            int age = 0;
            age = DateTime.Now.Subtract(Convert.ToDateTime(DOB)).Days;
            age = age / 365;
            return age;
        }
    }

   
}
