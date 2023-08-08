using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class ContractSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Contracts_ContractId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_ContractId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Seasons");

            migrationBuilder.CreateTable(
                name: "ContractSeason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractSeason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractSeason_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractSeason_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractSeason_ContractId",
                table: "ContractSeason",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractSeason_SeasonId",
                table: "ContractSeason",
                column: "SeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractSeason");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ContractId",
                table: "Seasons",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Contracts_ContractId",
                table: "Seasons",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}
