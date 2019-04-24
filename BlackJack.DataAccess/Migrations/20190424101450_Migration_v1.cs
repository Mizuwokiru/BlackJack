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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: true),
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
                    CreationTime = table.Column<DateTime>(nullable: true),
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
                    CreationTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: true),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundCards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: true),
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
                    { 1L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 1, 1 },
                    { 29L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 3, 3 },
                    { 30L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 4, 3 },
                    { 31L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 5, 3 },
                    { 32L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 6, 3 },
                    { 33L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 7, 3 },
                    { 34L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 8, 3 },
                    { 35L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 9, 3 },
                    { 36L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 10, 3 },
                    { 37L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 11, 3 },
                    { 38L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 12, 3 },
                    { 39L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 13, 3 },
                    { 40L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 1, 4 },
                    { 41L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 2, 4 },
                    { 42L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 3, 4 },
                    { 43L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 4, 4 },
                    { 44L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 5, 4 },
                    { 45L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 6, 4 },
                    { 46L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 7, 4 },
                    { 47L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 8, 4 },
                    { 48L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 9, 4 },
                    { 49L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 10, 4 },
                    { 50L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 11, 4 },
                    { 51L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 12, 4 },
                    { 28L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 2, 3 },
                    { 52L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 13, 4 },
                    { 27L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 1, 3 },
                    { 25L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 12, 2 },
                    { 2L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 2, 1 },
                    { 3L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 3, 1 },
                    { 4L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 4, 1 },
                    { 5L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 5, 1 },
                    { 6L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 6, 1 },
                    { 7L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 7, 1 },
                    { 8L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 8, 1 },
                    { 9L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 9, 1 },
                    { 10L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 10, 1 },
                    { 11L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 11, 1 },
                    { 12L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 12, 1 },
                    { 13L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 13, 1 },
                    { 14L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 1, 2 },
                    { 15L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 2, 2 },
                    { 16L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 3, 2 },
                    { 17L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 4, 2 },
                    { 18L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 5, 2 },
                    { 19L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 6, 2 },
                    { 20L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 7, 2 },
                    { 21L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 8, 2 },
                    { 22L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 9, 2 },
                    { 23L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 10, 2 },
                    { 24L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 11, 2 },
                    { 26L, new DateTime(2019, 4, 24, 13, 14, 49, 930, DateTimeKind.Local), 13, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreationTime", "Name", "Type" },
                values: new object[] { 1L, new DateTime(2019, 4, 24, 13, 14, 49, 933, DateTimeKind.Local), "Dealer", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerId",
                table: "AspNetUsers",
                column: "PlayerId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RoundCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
