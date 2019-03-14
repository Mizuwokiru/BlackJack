using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundGamePlayerCards_RoundGamePlayers_RoundGamePlayerId",
                table: "RoundGamePlayerCards");

            migrationBuilder.DropTable(
                name: "RoundGamePlayers");

            migrationBuilder.DropColumn(
                name: "PlayerCount",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "RoundGamePlayerId",
                table: "RoundGamePlayerCards",
                newName: "RoundId");

            migrationBuilder.RenameIndex(
                name: "IX_RoundGamePlayerCards_RoundGamePlayerId",
                table: "RoundGamePlayerCards",
                newName: "IX_RoundGamePlayerCards_RoundId");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rounds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamePlayerId",
                table: "RoundGamePlayerCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_GamePlayerId",
                table: "RoundGamePlayerCards",
                column: "GamePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundGamePlayerCards_GamePlayers_GamePlayerId",
                table: "RoundGamePlayerCards",
                column: "GamePlayerId",
                principalTable: "GamePlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundGamePlayerCards_Rounds_RoundId",
                table: "RoundGamePlayerCards",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundGamePlayerCards_GamePlayers_GamePlayerId",
                table: "RoundGamePlayerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundGamePlayerCards_Rounds_RoundId",
                table: "RoundGamePlayerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_RoundGamePlayerCards_GamePlayerId",
                table: "RoundGamePlayerCards");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "GamePlayerId",
                table: "RoundGamePlayerCards");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "RoundGamePlayerCards",
                newName: "RoundGamePlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_RoundGamePlayerCards_RoundId",
                table: "RoundGamePlayerCards",
                newName: "IX_RoundGamePlayerCards_RoundGamePlayerId");

            migrationBuilder.AddColumn<int>(
                name: "PlayerCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoundGamePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    GamePlayerId = table.Column<int>(nullable: true),
                    IsWon = table.Column<bool>(nullable: false),
                    RoundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundGamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundGamePlayers_GamePlayers_GamePlayerId",
                        column: x => x.GamePlayerId,
                        principalTable: "GamePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundGamePlayers_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayers_GamePlayerId",
                table: "RoundGamePlayers",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayers_RoundId",
                table: "RoundGamePlayers",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundGamePlayerCards_RoundGamePlayers_RoundGamePlayerId",
                table: "RoundGamePlayerCards",
                column: "RoundGamePlayerId",
                principalTable: "RoundGamePlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
