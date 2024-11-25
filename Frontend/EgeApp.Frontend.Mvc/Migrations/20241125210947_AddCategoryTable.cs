using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b3ac6da-062a-488a-9bee-62e2d4981d66", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b730d4cf-d754-4bc2-b79e-38f0bd3ece2e", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "849be6de-9277-44bc-a72f-83d92ae25b5d", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b3ac6da-062a-488a-9bee-62e2d4981d66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "849be6de-9277-44bc-a72f-83d92ae25b5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b730d4cf-d754-4bc2-b79e-38f0bd3ece2e");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7b3ac6da-062a-488a-9bee-62e2d4981d66", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" },
                    { "849be6de-9277-44bc-a72f-83d92ae25b5d", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "b730d4cf-d754-4bc2-b79e-38f0bd3ece2e", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2159562-0b52-4d58-aabd-75d627ed3f13", "AQAAAAIAAYagAAAAEMomYyKDw5HwyQnVv5jrUd0q3IRsFUNUOt8JXIlX6XHcdleBjJrWsH5BkVl8gtGxcQ==", "23f054f4-f4ba-47ee-8ee1-cd9bd937aaab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b40047c3-a396-4d0e-9c51-61881264edbe", "AQAAAAIAAYagAAAAEHKN5m+b8PEnRQeuW9/IDjcQeJ0HZpV8fkrZcWC70h4CCRCyncm/O9ZUtNlVQSo/OQ==", "0d6ade73-bba7-447d-add0-7ed350b92a84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3dcf1e6-80d2-43b5-91b7-87ce71a3e0f7", "AQAAAAIAAYagAAAAEPUlXncHZoAt0Kjtr9f0NDKJPUiQDP697uwiHHX8xsx5gXx64me/h3XNjJR/BdKDKw==", "7016a462-7651-478d-b418-6c292cd24fd2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7b3ac6da-062a-488a-9bee-62e2d4981d66", "1" },
                    { "b730d4cf-d754-4bc2-b79e-38f0bd3ece2e", "2" },
                    { "849be6de-9277-44bc-a72f-83d92ae25b5d", "3" }
                });
        }
    }
}
