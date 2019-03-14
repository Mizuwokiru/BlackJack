using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundGamePlayerCards");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Rounds",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Players",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Games",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "GamePlayers",
                newName: "CreatioinTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Cards",
                newName: "CreatioinTime");

            migrationBuilder.CreateTable(
                name: "RoundPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatioinTime = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true),
                    IsWon = table.Column<bool>(nullable: false),
                    RoundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundPlayers_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundPlayerCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatioinTime = table.Column<DateTime>(nullable: false),
                    CardId = table.Column<int>(nullable: true),
                    RoundPlayerId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerCards_CardId",
                table: "RoundPlayerCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerCards_RoundPlayerId",
                table: "RoundPlayerCards",
                column: "RoundPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayers_PlayerId",
                table: "RoundPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayers_RoundId",
                table: "RoundPlayers",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundPlayerCards");

            migrationBuilder.DropTable(
                name: "RoundPlayers");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Rounds",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Players",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Games",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "GamePlayers",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatioinTime",
                table: "Cards",
                newName: "CreationDate");

            migrationBuilder.CreateTable(
                name: "RoundGamePlayerCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    GamePlayerId = table.Column<int>(nullable: true),
                    RoundId = table.Column<int>(nullable: true)
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
                        name: "FK_RoundGamePlayerCards_GamePlayers_GamePlayerId",
                        column: x => x.GamePlayerId,
                        principalTable: "GamePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundGamePlayerCards_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_CardId",
                table: "RoundGamePlayerCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_GamePlayerId",
                table: "RoundGamePlayerCards",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGamePlayerCards_RoundId",
                table: "RoundGamePlayerCards",
                column: "RoundId");
        }
    }
}
