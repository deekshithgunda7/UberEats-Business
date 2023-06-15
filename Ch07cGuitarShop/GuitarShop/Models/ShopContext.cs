using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Restaurent" },
                new Category { CategoryID = 2, Name = "Grocery" },
                new Category { CategoryID = 3, Name = "Alcohol" },
                new Category {CategoryID=4, Name="Convienience"},
                new Category {CategoryID=5, Name="Flower shop"},
                new Category {CategoryID=6,Name="Pet Store"},
                new Category {CategoryID=7,Name="retail"}

            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1, 
                    CategoryID = 1,
                    BusinessName = "strat",
                    BusinessAddress = "Stratocaster",
                    BusinessEmail = "Stratocaster@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 2,
                    CategoryID = 1,
                    BusinessName = "les_paul",
                    BusinessAddress = "Gibson Les Paul",
                    BusinessEmail = "les_paul@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 3,
                    CategoryID = 1,
                    BusinessName = "sg",
                    BusinessAddress = "Gibson SG",
                    BusinessEmail = "sg@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 4,
                    CategoryID = 7,
                    BusinessName = "fg700s",
                    BusinessAddress = "Yamaha FG700S",
                    BusinessEmail = "fg700s@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 5,
                    CategoryID = 7,
                    BusinessName = "washburn",
                    BusinessAddress = "Washburn D10S",
                    BusinessEmail = "washburn@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 6,
                    CategoryID = 4,
                    BusinessName = "rodriguez",
                    BusinessAddress = "Rodriguez Caballero 11",
                    BusinessEmail = "rodriguez@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 7,
                    CategoryID = 2,
                    BusinessName = "precision",
                    BusinessAddress = "Fender Precision",
                    BusinessEmail = "precision@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 8,
                    CategoryID = 2,
                    BusinessName = "hofner",
                    BusinessAddress = "Hofner Icon",
                    BusinessEmail = "hofner@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 9,
                    CategoryID = 3,
                    BusinessName = "ludwig",
                    BusinessAddress = "Ludwig 5-piece Drum Set with Cymbals",
                    BusinessEmail = "ludwig@gmail.com",
                    BusinessPhone = 908876754
                },
                new Product
                {
                    ProductID = 10,
                    CategoryID = 3,
                    BusinessName = "tama",
                    BusinessAddress = "Tama 5-Piece Drum Set with Cymbals",
                    BusinessEmail = "tama@gmail.com",
                    BusinessPhone = 908876754
                }
            );
        }
    }
}