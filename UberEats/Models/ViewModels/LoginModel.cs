using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool RemeberMe { get; set; } = false;
    }
}
