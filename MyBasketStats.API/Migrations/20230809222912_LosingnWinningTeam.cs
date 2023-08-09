using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class LosingnWinningTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LosingTeamId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinningTeamId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_LosingTeamId",
                table: "Games",
                column: "LosingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinningTeamId",
                table: "Games",
                column: "WinningTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_LosingTeamId",
                table: "Games",
                column: "LosingTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_WinningTeamId",
                table: "Games",
                column: "WinningTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_LosingTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_WinningTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LosingTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WinningTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LosingTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WinningTeamId",
                table: "Games");
        }
    }
}
