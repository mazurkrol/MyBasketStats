using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameStatsheets_HomeTeamGameStatsheetId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameStatsheets_RoadTeamGameStatsheetId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameStatsheets");

            migrationBuilder.CreateTable(
                name: "TeamGameStatsheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoPointersMade = table.Column<int>(type: "int", nullable: false),
                    TwoPointersAttempted = table.Column<int>(type: "int", nullable: false),
                    ThreePointersMade = table.Column<int>(type: "int", nullable: false),
                    ThreePointersAttempted = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsMade = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsAttempted = table.Column<int>(type: "int", nullable: false),
                    Rebounds = table.Column<int>(type: "int", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGameStatsheets", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamGameStatsheets_HomeTeamGameStatsheetId",
                table: "Games",
                column: "HomeTeamGameStatsheetId",
                principalTable: "TeamGameStatsheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamGameStatsheets_RoadTeamGameStatsheetId",
                table: "Games",
                column: "RoadTeamGameStatsheetId",
                principalTable: "TeamGameStatsheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamGameStatsheets_HomeTeamGameStatsheetId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamGameStatsheets_RoadTeamGameStatsheetId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "TeamGameStatsheets");

            migrationBuilder.CreateTable(
                name: "GameStatsheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsAttempted = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsMade = table.Column<int>(type: "int", nullable: false),
                    Rebounds = table.Column<int>(type: "int", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    ThreePointersAttempted = table.Column<int>(type: "int", nullable: false),
                    ThreePointersMade = table.Column<int>(type: "int", nullable: false),
                    TwoPointersAttempted = table.Column<int>(type: "int", nullable: false),
                    TwoPointersMade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStatsheets", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameStatsheets_HomeTeamGameStatsheetId",
                table: "Games",
                column: "HomeTeamGameStatsheetId",
                principalTable: "GameStatsheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameStatsheets_RoadTeamGameStatsheetId",
                table: "Games",
                column: "RoadTeamGameStatsheetId",
                principalTable: "GameStatsheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
