using System.ComponentModel.DataAnnotations;

namespace UberEats.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuCategoryId { get; set; }
        public int PartnerId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual MenuCategory? MenuCategory { get; set; }
    }
}
