using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_PlayerForeignKey",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "GottenCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_PlayerForeignKey",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Bet",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameColumn(
                name: "PlayerForeignKey",
                table: "Rounds",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "IsDealer",
                table: "Players",
                newName: "IsBot");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Games",
                newName: "CreationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Rounds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundGamePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RoundId = table.Column<int>(nullable: true),
                    GamePlayerId = table.Column<int>(nullable: true),
                    IsWon = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RoundGamePlayerCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RoundGamePlayerId = table.Column<int>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundGamePlayerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundGamePlayerCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundGamePlayerCards_RoundGamePlayers_RoundGamePlayerId",
                        column: x => x.RoundGamePlayerId,
                        principalTable: "RoundGamePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_GameId",
                table: "GamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayerId",
                table: "GamePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_CardId",
                table: "RoundGamePlayerCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_RoundGamePlayerId",
                table: "RoundGamePlayerCards",
                column: "RoundGamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayers_GamePlayerId",
                table: "RoundGamePlayers",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayers_RoundId",
                table: "RoundGamePlayers",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundGamePlayerCards");

            migrationBuilder.DropTable(
                name: "RoundGamePlayers");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rounds",
                newName: "PlayerForeignKey");

            migrationBuilder.RenameColumn(
                name: "IsBot",
                table: "Players",
                newName: "IsDealer");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Games",
                newName: "StartTime");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rounds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Bet",
                table: "Players",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cash",
                table: "Players",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GottenCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GottenCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GottenCards_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GottenCards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Money = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlayerForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Players_PlayerForeignKey",
                        column: x => x.PlayerForeignKey,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_PlayerForeignKey",
                table: "Rounds",
                column: "PlayerForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GottenCards_CardId",
                table: "GottenCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_GottenCards_PlayerId",
                table: "GottenCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlayerForeignKey",
                table: "Users",
                column: "PlayerForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Players_PlayerForeignKey",
                table: "Rounds",
                column: "PlayerForeignKey",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
