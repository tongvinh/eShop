using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("62553e08-1ba1-475f-a059-003e621285ed"),
                column: "ConcurrencyStamp",
                value: "c6d056f3-6f90-46b1-89f8-40500b764da3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1898638-1c43-49d9-9037-5a1b229be8e1", "AQAAAAEAACcQAAAAEEGyni+OV8sgBLF3Ggynbnmr5JLOONyAhRzmhBJVDfHbGXKVgoJhAuPTrGnM4rZCsQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 26, 12, 37, 28, 942, DateTimeKind.Local).AddTicks(1145));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("62553e08-1ba1-475f-a059-003e621285ed"),
                column: "ConcurrencyStamp",
                value: "19ba7511-a543-412a-9a2b-40dd90e2e687");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d32c16e0-09ac-4e65-929f-11b670f7cb10", "AQAAAAEAACcQAAAAEDW73Ru+hppyStG+sWW/Iqv4u+Y/U1QIaZcqGEo+KDwEG8wpH+9PNltUZDaz/Wmb3g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 25, 14, 55, 56, 287, DateTimeKind.Local).AddTicks(9397));
        }
    }
}
