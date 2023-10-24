namespace UberEats.Models
{
    public class MenuListViewModel
    {
        public string Partner { get; set; }
        public int PartnerId { get; set; }
        public int ActiveMenuCategory { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
        public List<MenuItem> Data { get; set; }
    }
}
