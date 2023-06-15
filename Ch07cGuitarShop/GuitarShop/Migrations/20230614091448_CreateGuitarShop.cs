using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarShop.Migrations
{
    public partial class CreateGuitarShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessPhone = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Restaurent" },
                    { 2, "Grocery" },
                    { 3, "Alcohol" },
                    { 4, "Convienience" },
                    { 5, "Flower shop" },
                    { 6, "Pet Store" },
                    { 7, "retail" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID" },
                values: new object[,]
                {
                    { 1, "Stratocaster", "Stratocaster@gmail.com", "strat", 908876754, 1 },
                    { 2, "Gibson Les Paul", "les_paul@gmail.com", "les_paul", 908876754, 1 },
                    { 3, "Gibson SG", "sg@gmail.com", "sg", 908876754, 1 },
                    { 4, "Yamaha FG700S", "fg700s@gmail.com", "fg700s", 908876754, 7 },
                    { 5, "Washburn D10S", "washburn@gmail.com", "washburn", 908876754, 7 },
                    { 6, "Rodriguez Caballero 11", "rodriguez@gmail.com", "rodriguez", 908876754, 4 },
                    { 7, "Fender Precision", "precision@gmail.com", "precision", 908876754, 2 },
                    { 8, "Hofner Icon", "hofner@gmail.com", "hofner", 908876754, 2 },
                    { 9, "Ludwig 5-piece Drum Set with Cymbals", "ludwig@gmail.com", "ludwig", 908876754, 3 },
                    { 10, "Tama 5-Piece Drum Set with Cymbals", "tama@gmail.com", "tama", 908876754, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
