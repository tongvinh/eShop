using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 24, 11, 7, 44, 853, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 24, 11, 7, 44, 853, DateTimeKind.Local).AddTicks(2968),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("62553e08-1ba1-475f-a059-003e621285ed"),
                column: "ConcurrencyStamp",
                value: "10bc29d2-7a6e-4276-86e2-81a0cbf84a30");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("860efb43-c1ea-4fed-b9be-df1b4f37bcab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58f02696-1547-4e50-a226-689200f6fd94", "AQAAAAEAACcQAAAAEElcs4uIDrIg6xLKQvHbT+CM3NB7k7ewiUAtibpvqdOQYztikFOQE6F98CHMA+z8Zw==" });

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
    }
}
