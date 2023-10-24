using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class Partners
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Please Enter Business Address")]
        public string BusinessAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Business Email")]
        public string BusinessEmail { get; set; }
        
        [Required(ErrorMessage = "Please Enter Business Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public int categoryID { get; set; }

        public int? StatusID { get;set; }
        public virtual Status? Status { get; set; }

        public virtual Category? Category { get; set; }

        public virtual IList<MenuItem>? MenuItems { get; set; }
    }
}
