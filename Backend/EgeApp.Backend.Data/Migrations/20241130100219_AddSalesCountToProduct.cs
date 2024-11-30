using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgeApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesCountToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesCount",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 30, 13, 2, 19, 116, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3210), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3210), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3220), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3220), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3220), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3220), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCategoryId", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3230), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3230), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3230), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3230), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCategoryId", "SalesCount" },
                values: new object[] { new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3240), new DateTime(2024, 11, 30, 13, 2, 19, 117, DateTimeKind.Local).AddTicks(3240), 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesCount",
                table: "Products");

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
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCategoryId" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5460), 4 });

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
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCategoryId" },
                values: new object[] { new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5480), new DateTime(2024, 11, 26, 22, 23, 46, 972, DateTimeKind.Local).AddTicks(5480), 6 });
        }
    }
}
