﻿namespace UberEats.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }  
        public virtual IList<MenuItem> MenuItems { get; set; }
    }
}
