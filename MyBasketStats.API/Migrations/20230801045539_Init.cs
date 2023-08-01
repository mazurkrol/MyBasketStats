using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryInUsd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStatsheets",
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
                    table.PrimaryKey("PK_GameStatsheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    RoadTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamGameStatsheetId = table.Column<int>(type: "int", nullable: false),
                    RoadTeamGameStatsheetId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamPoints = table.Column<int>(type: "int", nullable: false),
                    RoadTeamPoints = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameStatsheets_HomeTeamGameStatsheetId",
                        column: x => x.HomeTeamGameStatsheetId,
                        principalTable: "GameStatsheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_GameStatsheets_RoadTeamGameStatsheetId",
                        column: x => x.RoadTeamGameStatsheetId,
                        principalTable: "GameStatsheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_RoadTeamId",
                        column: x => x.RoadTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeightInCm = table.Column<int>(type: "int", nullable: false),
                    HeightInInches = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    TotalStatsheetId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ChampionshipTeamId = table.Column<int>(type: "int", nullable: true),
                    FinalsMvpId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seasons_Players_FinalsMvpId",
                        column: x => x.FinalsMvpId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seasons_Teams_ChampionshipTeamId",
                        column: x => x.ChampionshipTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statsheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: true),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    TwoPointersMade = table.Column<int>(type: "int", nullable: false),
                    TwoPointersAttempted = table.Column<int>(type: "int", nullable: false),
                    ThreePointersMade = table.Column<int>(type: "int", nullable: false),
                    ThreePointersAttempted = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsMade = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsAttempted = table.Column<int>(type: "int", nullable: false),
                    Rebounds = table.Column<int>(type: "int", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statsheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statsheets_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statsheets_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamGameStatsheetId",
                table: "Games",
                column: "HomeTeamGameStatsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RoadTeamGameStatsheetId",
                table: "Games",
                column: "RoadTeamGameStatsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RoadTeamId",
                table: "Games",
                column: "RoadTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SeasonId",
                table: "Games",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ContractId",
                table: "Players",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TotalStatsheetId",
                table: "Players",
                column: "TotalStatsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ChampionshipTeamId",
                table: "Seasons",
                column: "ChampionshipTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ContractId",
                table: "Seasons",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_FinalsMvpId",
                table: "Seasons",
                column: "FinalsMvpId");

            migrationBuilder.CreateIndex(
                name: "IX_Statsheets_PlayerId",
                table: "Statsheets",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Statsheets_SeasonId",
                table: "Statsheets",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Seasons_SeasonId",
                table: "Games",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Statsheets_TotalStatsheetId",
                table: "Players",
                column: "TotalStatsheetId",
                principalTable: "Statsheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statsheets_Seasons_SeasonId",
                table: "Statsheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Contracts_ContractId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Statsheets_TotalStatsheetId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameStatsheets");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Statsheets");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
