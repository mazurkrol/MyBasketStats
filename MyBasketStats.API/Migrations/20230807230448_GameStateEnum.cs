using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class GameStateEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameState",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameState",
                table: "Games");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
