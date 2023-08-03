using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class Datename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Games",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Games",
                newName: "DateTime");
        }
    }
}
