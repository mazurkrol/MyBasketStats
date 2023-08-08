using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBasketStats.API.Migrations
{
    public partial class ContractSeason1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractSeason_Contracts_ContractId",
                table: "ContractSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractSeason_Seasons_SeasonId",
                table: "ContractSeason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractSeason",
                table: "ContractSeason");

            migrationBuilder.RenameTable(
                name: "ContractSeason",
                newName: "ContractSeasons");

            migrationBuilder.RenameIndex(
                name: "IX_ContractSeason_SeasonId",
                table: "ContractSeasons",
                newName: "IX_ContractSeasons_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractSeason_ContractId",
                table: "ContractSeasons",
                newName: "IX_ContractSeasons_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractSeasons",
                table: "ContractSeasons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractSeasons_Contracts_ContractId",
                table: "ContractSeasons",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractSeasons_Seasons_SeasonId",
                table: "ContractSeasons",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractSeasons_Contracts_ContractId",
                table: "ContractSeasons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractSeasons_Seasons_SeasonId",
                table: "ContractSeasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractSeasons",
                table: "ContractSeasons");

            migrationBuilder.RenameTable(
                name: "ContractSeasons",
                newName: "ContractSeason");

            migrationBuilder.RenameIndex(
                name: "IX_ContractSeasons_SeasonId",
                table: "ContractSeason",
                newName: "IX_ContractSeason_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractSeasons_ContractId",
                table: "ContractSeason",
                newName: "IX_ContractSeason_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractSeason",
                table: "ContractSeason",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractSeason_Contracts_ContractId",
                table: "ContractSeason",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractSeason_Seasons_SeasonId",
                table: "ContractSeason",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
