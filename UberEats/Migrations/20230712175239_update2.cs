using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_StatusID",
                table: "Drivers",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Statuses_StatusID",
                table: "Drivers",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Statuses_StatusID",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_StatusID",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Drivers");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
