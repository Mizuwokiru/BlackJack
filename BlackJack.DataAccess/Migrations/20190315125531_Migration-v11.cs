using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class Migrationv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationTime", "Rank", "Suit" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 15, 14, 55, 30, 889, DateTimeKind.Local).AddTicks(8247), 1, 1 },
                    { 29, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3338), 3, 3 },
                    { 30, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3341), 4, 3 },
                    { 31, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3341), 5, 3 },
                    { 32, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3345), 6, 3 },
                    { 33, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3348), 7, 3 },
                    { 34, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3348), 8, 3 },
                    { 35, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3352), 9, 3 },
                    { 36, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3356), 10, 3 },
                    { 37, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3356), 11, 3 },
                    { 38, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3359), 12, 3 },
                    { 28, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3338), 2, 3 },
                    { 39, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3359), 13, 3 },
                    { 41, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3367), 2, 4 },
                    { 42, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3370), 3, 4 },
                    { 43, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3370), 4, 4 },
                    { 44, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3374), 5, 4 },
                    { 45, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3378), 6, 4 },
                    { 46, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3378), 7, 4 },
                    { 47, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3381), 8, 4 },
                    { 48, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3385), 9, 4 },
                    { 49, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3385), 10, 4 },
                    { 50, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3389), 11, 4 },
                    { 40, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3367), 1, 4 },
                    { 27, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3334), 1, 3 },
                    { 26, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3316), 13, 2 },
                    { 25, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3312), 12, 2 },
                    { 2, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2667), 2, 1 },
                    { 3, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2681), 3, 1 },
                    { 4, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2685), 4, 1 },
                    { 5, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2688), 5, 1 },
                    { 6, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2692), 6, 1 },
                    { 7, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2696), 7, 1 },
                    { 8, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2732), 8, 1 },
                    { 9, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2736), 9, 1 },
                    { 10, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2739), 10, 1 },
                    { 11, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2739), 11, 1 },
                    { 12, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2743), 12, 1 },
                    { 13, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(2743), 13, 1 },
                    { 14, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3283), 1, 2 },
                    { 15, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3290), 2, 2 },
                    { 16, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3294), 3, 2 },
                    { 17, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3294), 4, 2 },
                    { 18, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3297), 5, 2 },
                    { 19, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3301), 6, 2 },
                    { 20, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3301), 7, 2 },
                    { 21, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3305), 8, 2 },
                    { 22, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3305), 9, 2 },
                    { 23, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3308), 10, 2 },
                    { 24, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3312), 11, 2 },
                    { 51, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3389), 12, 4 },
                    { 52, new DateTime(2019, 3, 15, 14, 55, 30, 891, DateTimeKind.Local).AddTicks(3392), 13, 4 }
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
