﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DataAccess.Migrations
{
    public partial class Migration_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWon",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 972, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 973, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 10, 10, 17, 974, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Rounds");

            migrationBuilder.AddColumn<bool>(
                name: "IsWon",
                table: "Rounds",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 382, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 383, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 4, 1, 9, 38, 30, 384, DateTimeKind.Local));
        }
    }
}
