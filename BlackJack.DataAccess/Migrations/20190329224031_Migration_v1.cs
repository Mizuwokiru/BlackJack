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
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsBot = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    IsWon = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    RoundId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundCards_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationTime", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 30, 0, 40, 31, 317, DateTimeKind.Local), 1, 1 },
                    { 29, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 3, 3 },
                    { 30, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 4, 3 },
                    { 31, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 5, 3 },
                    { 32, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 6, 3 },
                    { 33, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 7, 3 },
                    { 34, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 8, 3 },
                    { 35, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 9, 3 },
                    { 36, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 10, 3 },
                    { 37, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 11, 3 },
                    { 38, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 12, 3 },
                    { 39, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 13, 3 },
                    { 40, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 1, 4 },
                    { 41, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 2, 4 },
                    { 42, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 3, 4 },
                    { 43, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 4, 4 },
                    { 44, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 5, 4 },
                    { 45, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 6, 4 },
                    { 46, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 7, 4 },
                    { 47, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 8, 4 },
                    { 48, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 9, 4 },
                    { 49, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 10, 4 },
                    { 50, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 11, 4 },
                    { 51, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 12, 4 },
                    { 28, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 2, 3 },
                    { 52, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 13, 4 },
                    { 27, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 1, 3 },
                    { 25, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 12, 2 },
                    { 2, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 2, 1 },
                    { 3, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 3, 1 },
                    { 4, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 4, 1 },
                    { 5, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 5, 1 },
                    { 6, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 6, 1 },
                    { 7, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 7, 1 },
                    { 8, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 8, 1 },
                    { 9, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 9, 1 },
                    { 10, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 10, 1 },
                    { 11, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 11, 1 },
                    { 12, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 12, 1 },
                    { 13, new DateTime(2019, 3, 30, 0, 40, 31, 318, DateTimeKind.Local), 13, 1 },
                    { 14, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 1, 2 },
                    { 15, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 2, 2 },
                    { 16, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 3, 2 },
                    { 17, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 4, 2 },
                    { 18, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 5, 2 },
                    { 19, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 6, 2 },
                    { 20, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 7, 2 },
                    { 21, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 8, 2 },
                    { 22, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 9, 2 },
                    { 23, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 10, 2 },
                    { 24, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 11, 2 },
                    { 26, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), 13, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreationTime", "IsBot", "Name" },
                values: new object[] { 1, new DateTime(2019, 3, 30, 0, 40, 31, 319, DateTimeKind.Local), true, "Dealer" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Suit_Rank",
                table: "Cards",
                columns: new[] { "Suit", "Rank" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_GameId",
                table: "GamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayerId",
                table: "GamePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoundCards_CardId",
                table: "RoundCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundCards_RoundId",
                table: "RoundCards",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_PlayerId",
                table: "Rounds",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "RoundCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
