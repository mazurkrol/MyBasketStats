using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class MoreStatsheetGameData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Blocks",
                table: "TeamGameStatsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fouls",
                table: "TeamGameStatsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Turnovers",
                table: "TeamGameStatsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Blocks",
                table: "Statsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fouls",
                table: "Statsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Turnovers",
                table: "Statsheets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocks",
                table: "TeamGameStatsheets");

            migrationBuilder.DropColumn(
                name: "Fouls",
                table: "TeamGameStatsheets");

            migrationBuilder.DropColumn(
                name: "Turnovers",
                table: "TeamGameStatsheets");

            migrationBuilder.DropColumn(
                name: "Blocks",
                table: "Statsheets");

            migrationBuilder.DropColumn(
                name: "Fouls",
                table: "Statsheets");

            migrationBuilder.DropColumn(
                name: "Turnovers",
                table: "Statsheets");
        }
    }
}
