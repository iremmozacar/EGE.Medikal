using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgeApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 12, 44, 85, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5310), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5320), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5330), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5330), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5340), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5350), new DateTime(2024, 11, 26, 22, 12, 44, 86, DateTimeKind.Local).AddTicks(5350) });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6320), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6340), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6360), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6370), new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6370) });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
