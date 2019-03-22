using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.EntityFramework.Migrations
{
    public partial class Migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationTime", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 22, 16, 46, 32, 185, DateTimeKind.Local), 1, 1 },
                    { 29, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 3, 3 },
                    { 30, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 4, 3 },
                    { 31, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 5, 3 },
                    { 32, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 6, 3 },
                    { 33, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 7, 3 },
                    { 34, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 8, 3 },
                    { 35, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 9, 3 },
                    { 36, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 10, 3 },
                    { 37, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 11, 3 },
                    { 38, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 12, 3 },
                    { 28, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 2, 3 },
                    { 39, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 13, 3 },
                    { 41, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 2, 4 },
                    { 42, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 3, 4 },
                    { 43, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 4, 4 },
                    { 44, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 5, 4 },
                    { 45, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 6, 4 },
                    { 46, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 7, 4 },
                    { 47, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 8, 4 },
                    { 48, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 9, 4 },
                    { 49, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 10, 4 },
                    { 50, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 11, 4 },
                    { 40, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 1, 4 },
                    { 27, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 1, 3 },
                    { 26, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 13, 2 },
                    { 25, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 12, 2 },
                    { 2, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 2, 1 },
                    { 3, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 3, 1 },
                    { 4, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 4, 1 },
                    { 5, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 5, 1 },
                    { 6, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 6, 1 },
                    { 7, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 7, 1 },
                    { 8, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 8, 1 },
                    { 9, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 9, 1 },
                    { 10, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 10, 1 },
                    { 11, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 11, 1 },
                    { 12, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 12, 1 },
                    { 13, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 13, 1 },
                    { 14, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 1, 2 },
                    { 15, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 2, 2 },
                    { 16, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 3, 2 },
                    { 17, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 4, 2 },
                    { 18, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 5, 2 },
                    { 19, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 6, 2 },
                    { 20, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 7, 2 },
                    { 21, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 8, 2 },
                    { 22, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 9, 2 },
                    { 23, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 10, 2 },
                    { 24, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 11, 2 },
                    { 51, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 12, 4 },
                    { 52, new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), 13, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 52);
        }
    }
}
