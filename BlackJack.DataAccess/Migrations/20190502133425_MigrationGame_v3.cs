using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class MigrationGame_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationTime", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 1, 1 },
                    { 29L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 3, 3 },
                    { 30L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 4, 3 },
                    { 31L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 5, 3 },
                    { 32L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 6, 3 },
                    { 33L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 7, 3 },
                    { 34L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 8, 3 },
                    { 35L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 9, 3 },
                    { 36L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 10, 3 },
                    { 37L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 11, 3 },
                    { 38L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 12, 3 },
                    { 39L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 13, 3 },
                    { 40L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 1, 4 },
                    { 41L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 2, 4 },
                    { 42L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 3, 4 },
                    { 43L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 4, 4 },
                    { 44L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 5, 4 },
                    { 45L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 6, 4 },
                    { 46L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 7, 4 },
                    { 47L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 8, 4 },
                    { 48L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 9, 4 },
                    { 49L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 10, 4 },
                    { 50L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 11, 4 },
                    { 51L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 12, 4 },
                    { 28L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 2, 3 },
                    { 52L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 13, 4 },
                    { 27L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 1, 3 },
                    { 25L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 12, 2 },
                    { 2L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 2, 1 },
                    { 3L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 3, 1 },
                    { 4L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 4, 1 },
                    { 5L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 5, 1 },
                    { 6L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 6, 1 },
                    { 7L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 7, 1 },
                    { 8L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 8, 1 },
                    { 9L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 9, 1 },
                    { 10L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 10, 1 },
                    { 11L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 11, 1 },
                    { 12L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 12, 1 },
                    { 13L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 13, 1 },
                    { 14L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 1, 2 },
                    { 15L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 2, 2 },
                    { 16L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 3, 2 },
                    { 17L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 4, 2 },
                    { 18L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 5, 2 },
                    { 19L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 6, 2 },
                    { 20L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 7, 2 },
                    { 21L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 8, 2 },
                    { 22L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 9, 2 },
                    { 23L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 10, 2 },
                    { 24L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 11, 2 },
                    { 26L, new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), 13, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 5, 2, 16, 34, 25, 167, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2019, 5, 2, 16, 29, 49, 196, DateTimeKind.Local));
        }
    }
}
