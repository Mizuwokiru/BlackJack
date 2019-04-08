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
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    State = table.Column<int>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    RoundId = table.Column<long>(nullable: false),
                    CardId = table.Column<long>(nullable: false)
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
                    { 1L, new DateTime(2019, 4, 8, 17, 12, 42, 160, DateTimeKind.Local), 1, 1 },
                    { 29L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 3, 3 },
                    { 30L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 4, 3 },
                    { 31L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 5, 3 },
                    { 32L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 6, 3 },
                    { 33L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 7, 3 },
                    { 34L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 8, 3 },
                    { 35L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 9, 3 },
                    { 36L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 10, 3 },
                    { 37L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 11, 3 },
                    { 38L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 12, 3 },
                    { 39L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 13, 3 },
                    { 40L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 1, 4 },
                    { 41L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 2, 4 },
                    { 42L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 3, 4 },
                    { 43L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 4, 4 },
                    { 44L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 5, 4 },
                    { 45L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 6, 4 },
                    { 46L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 7, 4 },
                    { 47L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 8, 4 },
                    { 48L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 9, 4 },
                    { 49L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 10, 4 },
                    { 50L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 11, 4 },
                    { 51L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 12, 4 },
                    { 28L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 2, 3 },
                    { 52L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 13, 4 },
                    { 27L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 1, 3 },
                    { 25L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 12, 2 },
                    { 2L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 2, 1 },
                    { 3L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 3, 1 },
                    { 4L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 4, 1 },
                    { 5L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 5, 1 },
                    { 6L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 6, 1 },
                    { 7L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 7, 1 },
                    { 8L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 8, 1 },
                    { 9L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 9, 1 },
                    { 10L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 10, 1 },
                    { 11L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 11, 1 },
                    { 12L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 12, 1 },
                    { 13L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 13, 1 },
                    { 14L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 1, 2 },
                    { 15L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 2, 2 },
                    { 16L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 3, 2 },
                    { 17L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 4, 2 },
                    { 18L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 5, 2 },
                    { 19L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 6, 2 },
                    { 20L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 7, 2 },
                    { 21L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 8, 2 },
                    { 22L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 9, 2 },
                    { 23L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 10, 2 },
                    { 24L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 11, 2 },
                    { 26L, new DateTime(2019, 4, 8, 17, 12, 42, 161, DateTimeKind.Local), 13, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreationTime", "Name", "Type" },
                values: new object[] { 1L, new DateTime(2019, 4, 8, 17, 12, 42, 162, DateTimeKind.Local), "Dealer", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Suit_Rank",
                table: "Cards",
                columns: new[] { "Suit", "Rank" },
                unique: true);

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
