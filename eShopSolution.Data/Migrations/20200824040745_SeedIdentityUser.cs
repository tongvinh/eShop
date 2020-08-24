using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 24, 11, 7, 44, 853, DateTimeKind.Local).AddTicks(2968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 24, 10, 54, 17, 358, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("62553e08-1ba1-475f-a059-003e621285ed"), "10bc29d2-7a6e-4276-86e2-81a0cbf84a30", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("62553e08-1ba1-475f-a059-003e621285ed"), new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab"), 0, "58f02696-1547-4e50-a226-689200f6fd94", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vinhtong@elandvn.com", true, "Eland", "CuChi", false, null, "vinhtong@elandvn.com", "admin", "AQAAAAEAACcQAAAAEElcs4uIDrIg6xLKQvHbT+CM3NB7k7ewiUAtibpvqdOQYztikFOQE6F98CHMA+z8Zw==", null, false, "", false, "admin" });

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
                value: new DateTime(2020, 8, 24, 11, 7, 44, 871, DateTimeKind.Local).AddTicks(9195));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("62553e08-1ba1-475f-a059-003e621285ed"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("62553e08-1ba1-475f-a059-003e621285ed"), new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 24, 10, 54, 17, 358, DateTimeKind.Local).AddTicks(2541),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 24, 11, 7, 44, 853, DateTimeKind.Local).AddTicks(2968));

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
                value: new DateTime(2020, 8, 24, 10, 54, 17, 373, DateTimeKind.Local).AddTicks(4585));
        }
    }
}
