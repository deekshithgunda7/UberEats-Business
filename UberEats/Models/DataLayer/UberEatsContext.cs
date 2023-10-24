using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer
{
    public class UberEatsContext : DbContext
    {
        public UberEatsContext(DbContextOptions<UberEatsContext> opt) : base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Restuarent" },
                new Category { Id = 2, Name = "Grocery" },
                new Category { Id = 3, Name = "Alcohol" },
                new Category { Id = 4, Name = "Convenience" },
                new Category { Id = 5, Name = "Flower Shop" },
                new Category { Id = 6, Name = "Pet Store" },
                new Category { Id = 7, Name = "Retail" }
                );
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "New" },
                new Status { Id = 2, Name = "Approved" },
                new Status { Id = 3, Name = "Rejected" }
                );

            modelBuilder.Entity<MenuCategory>().HasData(
               new MenuCategory { Id = 1, CategoryId = 1, Name = "Appetizer" },
               new MenuCategory { Id = 2, CategoryId = 1, Name = "Soup" },
               new MenuCategory { Id = 3, CategoryId = 1, Name = "Salad" },
               new MenuCategory { Id = 4, CategoryId = 1, Name = "Main Course" },
               new MenuCategory { Id = 5, CategoryId = 1, Name = "Dessert" },
               new MenuCategory { Id = 6, CategoryId = 1, Name = "Drink" },
               new MenuCategory { Id = 7, CategoryId = 1, Name = "Vegetarian" }
               );
        }
    }
}
