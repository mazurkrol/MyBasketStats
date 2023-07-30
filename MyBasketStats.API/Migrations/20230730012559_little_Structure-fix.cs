using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class little_Structurefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Seasons");
        }
    }
}
