using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class Migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Suit = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    RoundId = table.Column<int>(nullable: true),
                    IsWon = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    BotId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundPlayers_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundPlayers_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundPlayers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundPlayerCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    RoundPlayerId = table.Column<int>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundPlayerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundPlayerCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundPlayerCards_RoundPlayers_RoundPlayerId",
                        column: x => x.RoundPlayerId,
                        principalTable: "RoundPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationTime", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 25, 10, 56, 38, 386, DateTimeKind.Local), 1, 1 },
                    { 29, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 3, 3 },
                    { 30, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 4, 3 },
                    { 31, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 5, 3 },
                    { 32, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 6, 3 },
                    { 33, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 7, 3 },
                    { 34, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 8, 3 },
                    { 35, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 9, 3 },
                    { 36, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 10, 3 },
                    { 37, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 11, 3 },
                    { 38, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 12, 3 },
                    { 28, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 2, 3 },
                    { 39, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 13, 3 },
                    { 41, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 2, 4 },
                    { 42, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 3, 4 },
                    { 43, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 4, 4 },
                    { 44, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 5, 4 },
                    { 45, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 6, 4 },
                    { 46, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 7, 4 },
                    { 47, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 8, 4 },
                    { 48, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 9, 4 },
                    { 49, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 10, 4 },
                    { 50, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 11, 4 },
                    { 40, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 1, 4 },
                    { 27, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 1, 3 },
                    { 26, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 13, 2 },
                    { 25, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 12, 2 },
                    { 2, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 2, 1 },
                    { 3, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 3, 1 },
                    { 4, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 4, 1 },
                    { 5, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 5, 1 },
                    { 6, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 6, 1 },
                    { 7, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 7, 1 },
                    { 8, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 8, 1 },
                    { 9, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 9, 1 },
                    { 10, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 10, 1 },
                    { 11, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 11, 1 },
                    { 12, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 12, 1 },
                    { 13, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 13, 1 },
                    { 14, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 1, 2 },
                    { 15, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 2, 2 },
                    { 16, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 3, 2 },
                    { 17, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 4, 2 },
                    { 18, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 5, 2 },
                    { 19, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 6, 2 },
                    { 20, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 7, 2 },
                    { 21, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 8, 2 },
                    { 22, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 9, 2 },
                    { 23, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 10, 2 },
                    { 24, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 11, 2 },
                    { 51, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 12, 4 },
                    { 52, new DateTime(2019, 3, 25, 10, 56, 38, 388, DateTimeKind.Local), 13, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bots_Name",
                table: "Bots",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Suit_Rank",
                table: "Cards",
                columns: new[] { "Suit", "Rank" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerCards_CardId",
                table: "RoundPlayerCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerCards_RoundPlayerId",
                table: "RoundPlayerCards",
                column: "RoundPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayers_RoundId",
                table: "RoundPlayers",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayers_BotId",
                table: "RoundPlayers",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayers_UserId",
                table: "RoundPlayers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundPlayerCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "RoundPlayers");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Bots");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
