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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsPlayable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
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
                    { 1, new DateTime(2019, 4, 1, 15, 6, 21, 692, DateTimeKind.Local), 1, 127136 },
                    { 29, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 3, 127168 },
                    { 30, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 4, 127168 },
                    { 31, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 5, 127168 },
                    { 32, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 6, 127168 },
                    { 33, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 7, 127168 },
                    { 34, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 8, 127168 },
                    { 35, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 9, 127168 },
                    { 36, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 10, 127168 },
                    { 37, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 11, 127168 },
                    { 38, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 13, 127168 },
                    { 39, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 14, 127168 },
                    { 40, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 1, 127184 },
                    { 41, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 2, 127184 },
                    { 42, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 3, 127184 },
                    { 43, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 4, 127184 },
                    { 44, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 5, 127184 },
                    { 45, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 6, 127184 },
                    { 46, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 7, 127184 },
                    { 47, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 8, 127184 },
                    { 48, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 9, 127184 },
                    { 49, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 10, 127184 },
                    { 50, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 11, 127184 },
                    { 51, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 13, 127184 },
                    { 28, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 2, 127168 },
                    { 52, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 14, 127184 },
                    { 27, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 1, 127168 },
                    { 25, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 13, 127152 },
                    { 2, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 2, 127136 },
                    { 3, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 3, 127136 },
                    { 4, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 4, 127136 },
                    { 5, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 5, 127136 },
                    { 6, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 6, 127136 },
                    { 7, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 7, 127136 },
                    { 8, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 8, 127136 },
                    { 9, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 9, 127136 },
                    { 10, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 10, 127136 },
                    { 11, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 11, 127136 },
                    { 12, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 13, 127136 },
                    { 13, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 14, 127136 },
                    { 14, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 1, 127152 },
                    { 15, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 2, 127152 },
                    { 16, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 3, 127152 },
                    { 17, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 4, 127152 },
                    { 18, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 5, 127152 },
                    { 19, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 6, 127152 },
                    { 20, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 7, 127152 },
                    { 21, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 8, 127152 },
                    { 22, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 9, 127152 },
                    { 23, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 10, 127152 },
                    { 24, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 11, 127152 },
                    { 26, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), 14, 127152 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreationTime", "IsPlayable", "Name" },
                values: new object[] { 1, new DateTime(2019, 4, 1, 15, 6, 21, 694, DateTimeKind.Local), false, "Dealer" });

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
