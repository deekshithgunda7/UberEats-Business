namespace UberEats.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<MenuCategory> MenuCategories { get; set; }
        public virtual IList<Partners>? Partners { get; set; }
    }
}
