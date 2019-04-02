using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class MigrationV1 : Migration
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
                    { 1L, new DateTime(2019, 4, 2, 17, 5, 35, 858, DateTimeKind.Local), 1, 127136 },
                    { 29L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 3, 127168 },
                    { 30L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 4, 127168 },
                    { 31L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 5, 127168 },
                    { 32L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 6, 127168 },
                    { 33L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 7, 127168 },
                    { 34L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 8, 127168 },
                    { 35L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 9, 127168 },
                    { 36L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 10, 127168 },
                    { 37L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 11, 127168 },
                    { 38L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 13, 127168 },
                    { 39L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 14, 127168 },
                    { 40L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 1, 127184 },
                    { 41L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 2, 127184 },
                    { 42L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 3, 127184 },
                    { 43L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 4, 127184 },
                    { 44L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 5, 127184 },
                    { 45L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 6, 127184 },
                    { 46L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 7, 127184 },
                    { 47L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 8, 127184 },
                    { 48L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 9, 127184 },
                    { 49L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 10, 127184 },
                    { 50L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 11, 127184 },
                    { 51L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 13, 127184 },
                    { 28L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 2, 127168 },
                    { 52L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 14, 127184 },
                    { 27L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 1, 127168 },
                    { 25L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 13, 127152 },
                    { 2L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 2, 127136 },
                    { 3L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 3, 127136 },
                    { 4L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 4, 127136 },
                    { 5L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 5, 127136 },
                    { 6L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 6, 127136 },
                    { 7L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 7, 127136 },
                    { 8L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 8, 127136 },
                    { 9L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 9, 127136 },
                    { 10L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 10, 127136 },
                    { 11L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 11, 127136 },
                    { 12L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 13, 127136 },
                    { 13L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 14, 127136 },
                    { 14L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 1, 127152 },
                    { 15L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 2, 127152 },
                    { 16L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 3, 127152 },
                    { 17L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 4, 127152 },
                    { 18L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 5, 127152 },
                    { 19L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 6, 127152 },
                    { 20L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 7, 127152 },
                    { 21L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 8, 127152 },
                    { 22L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 9, 127152 },
                    { 23L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 10, 127152 },
                    { 24L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 11, 127152 },
                    { 26L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), 14, 127152 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreationTime", "Name", "Type" },
                values: new object[] { 1L, new DateTime(2019, 4, 2, 17, 5, 35, 860, DateTimeKind.Local), "Dealer", 3 });

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
