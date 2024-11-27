using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgeApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryEdited2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 22, 23, 46, 971, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5430), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5480), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5480) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ParentId",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
