using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed5f4adf-d1d1-4b22-b534-a45ec7e30e55", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f54c18a-7f11-444c-b4df-6a1c81732a80", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "75a05420-3d40-41fd-8a7d-4ffe7b846122", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f54c18a-7f11-444c-b4df-6a1c81732a80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a05420-3d40-41fd-8a7d-4ffe7b846122");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5f4adf-d1d1-4b22-b534-a45ec7e30e55");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2757fd53-eb98-4416-a9ae-c3c4ba49fc95", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "931cfd6a-1407-4b39-b13c-83ce2dcf8790", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" },
                    { "e98a6b99-03df-4f1f-b417-52c2e3d4813f", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38bf11d9-8bb6-4e77-9906-2d2b0d5dca2c", "AQAAAAIAAYagAAAAELKhg0vPc0FFl3AA7ZUNFiF27Pf6LbADipPZoLEkkuEJAJRbHY8wafKf0/suyrzBgQ==", "7bc68288-a5da-4bee-a837-70c80ba95b16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8583315-4c1b-448a-8923-7bb93765e9fc", "AQAAAAIAAYagAAAAED8xw55Mi1PJK4jxQuSiuElLzzYrHK0Qc/8xAKUYvdZDEq2pbRQ3dQdQ1vRQF4WLLw==", "5a449c3b-5ad6-4ea9-9e92-7a6d2b1ac3fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "809b7c7b-a4a5-4059-995d-a9ba908a389e", "AQAAAAIAAYagAAAAEH/aKwDlVKreekBepdDBSgZxMQsXlqjiMe7paSZUiFmIX84eyFpkAnTYV0dcJtLbkQ==", "e0902d31-d987-44af-94bb-21a20ff06412" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e98a6b99-03df-4f1f-b417-52c2e3d4813f", "1" },
                    { "931cfd6a-1407-4b39-b13c-83ce2dcf8790", "2" },
                    { "2757fd53-eb98-4416-a9ae-c3c4ba49fc95", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e98a6b99-03df-4f1f-b417-52c2e3d4813f", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "931cfd6a-1407-4b39-b13c-83ce2dcf8790", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2757fd53-eb98-4416-a9ae-c3c4ba49fc95", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2757fd53-eb98-4416-a9ae-c3c4ba49fc95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "931cfd6a-1407-4b39-b13c-83ce2dcf8790");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e98a6b99-03df-4f1f-b417-52c2e3d4813f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f54c18a-7f11-444c-b4df-6a1c81732a80", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" },
                    { "75a05420-3d40-41fd-8a7d-4ffe7b846122", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "ed5f4adf-d1d1-4b22-b534-a45ec7e30e55", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "190bcaae-855b-48e4-8d28-13d1da9cefaf", "AQAAAAIAAYagAAAAENMm4d+4JPuZCnVqy0uHZNzGQDhVW9pBAKmQhZQ5GCMtxcx8USd7lZgf29N+9kHkpg==", "99961506-c42f-4e2b-91ac-954fe708492b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c010b6e-fb8f-440e-b501-182b0af9225d", "AQAAAAIAAYagAAAAEPAPvawPiyxhbCMgWJVLmucC+IjwVJtrQwUtiD64ADoDs/DQNHdfzDjfY0s/ceSjvA==", "f63268ac-d14c-44e2-b5a3-e636561552d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71325787-868a-409a-b0e0-b3ad6c7a3e7f", "AQAAAAIAAYagAAAAENyQXl6k0E4qaYPN3zeZh2kzi3yQvktUZogKo67oO6dcSShtK8WLnsUuq67bJ+FhWQ==", "bc48232c-2180-4f55-8d0d-80a70b81bb6c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ed5f4adf-d1d1-4b22-b534-a45ec7e30e55", "1" },
                    { "3f54c18a-7f11-444c-b4df-6a1c81732a80", "2" },
                    { "75a05420-3d40-41fd-8a7d-4ffe7b846122", "3" }
                });
        }
    }
}
