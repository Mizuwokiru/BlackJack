using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Rounds",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "RoundPlayers",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "RoundPlayerCards",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Players",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Games",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "GamePlayers",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Cards",
                newName: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Rounds",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "RoundPlayers",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "RoundPlayerCards",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Players",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Games",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "GamePlayers",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Cards",
                newName: "CreatioinTime");
        }
    }
}
