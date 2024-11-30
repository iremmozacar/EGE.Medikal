using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "925b55bf-76e5-419b-9461-0c5280ee861a", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bb9d707-b1ea-4d95-854b-3c63cbfccf1f", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "503f77cf-f35e-4ee4-8ba5-f48fa01d8225", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bb9d707-b1ea-4d95-854b-3c63cbfccf1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "503f77cf-f35e-4ee4-8ba5-f48fa01d8225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "925b55bf-76e5-419b-9461-0c5280ee861a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3bb9d707-b1ea-4d95-854b-3c63cbfccf1f", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" },
                    { "503f77cf-f35e-4ee4-8ba5-f48fa01d8225", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "925b55bf-76e5-419b-9461-0c5280ee861a", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4b1633e-77bd-48f6-b6e7-449620999e0a", "AQAAAAIAAYagAAAAEHKHp7DBg92iybi0gyT4T95367MsZkSEcaleZX3Ww3DX5OEqLyQ2fizKS6pOY8vxqw==", "856ed5d8-cbb0-45c8-9a51-36ad4d0ce1df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df382785-e2c0-464e-a5c0-46116101c9b7", "AQAAAAIAAYagAAAAEDlF3Vn/+jFznDZjHvzu+Dw8MJEvC13VufAie42dFEI3NT5HsVaNmuQrKXWBicJmow==", "15425bf4-8380-4828-97cb-4660c5db9800" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91195142-edb9-4847-83f9-bb6f125bcc63", "AQAAAAIAAYagAAAAEKBxRlAUInhMdpclU4GCsJxue2xgQJjxXoTWoPJiEyezswsbSNvAq+nIFtQgyRZehw==", "2477e053-5930-4dcd-b570-b8db6a6bc71d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "925b55bf-76e5-419b-9461-0c5280ee861a", "1" },
                    { "3bb9d707-b1ea-4d95-854b-3c63cbfccf1f", "2" },
                    { "503f77cf-f35e-4ee4-8ba5-f48fa01d8225", "3" }
                });
        }
    }
}
