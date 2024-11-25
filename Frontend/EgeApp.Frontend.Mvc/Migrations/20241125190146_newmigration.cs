using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8277277-393d-441f-a66f-b25ea2a453f6", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49bb0905-f559-4d1f-b21d-6f36315a5def", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49bb0905-f559-4d1f-b21d-6f36315a5def", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49bb0905-f559-4d1f-b21d-6f36315a5def", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49bb0905-f559-4d1f-b21d-6f36315a5def", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49bb0905-f559-4d1f-b21d-6f36315a5def");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7510d57-b162-47fd-a5cb-4ca542ef72e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8277277-393d-441f-a66f-b25ea2a453f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6");

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d2159562-0b52-4d58-aabd-75d627ed3f13", "Muhammed", "Topçu", "MUHAMMEDTOPCU@EXAMPLE.COM", "MUHAMMEDTOPCU", "AQAAAAIAAYagAAAAEMomYyKDw5HwyQnVv5jrUd0q3IRsFUNUOt8JXIlX6XHcdleBjJrWsH5BkVl8gtGxcQ==", "23f054f4-f4ba-47ee-8ee1-cd9bd937aaab", "muhammedtopcu" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b40047c3-a396-4d0e-9c51-61881264edbe", "iremozacaar@gmail.com", "İrem", "Özacar", "IREMOZACAAR@EXAMPLE.COM", "IREMOZACAR", "AQAAAAIAAYagAAAAEHKN5m+b8PEnRQeuW9/IDjcQeJ0HZpV8fkrZcWC70h4CCRCyncm/O9ZUtNlVQSo/OQ==", "0d6ade73-bba7-447d-add0-7ed350b92a84", "iremozacar" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a3dcf1e6-80d2-43b5-91b7-87ce71a3e0f7", "fatmanuraltin@example.com", "Fatmanur", "Altın", "FATMANURALTIN@EXAMPLE.COM", "FATMANURALTIN", "AQAAAAIAAYagAAAAEPUlXncHZoAt0Kjtr9f0NDKJPUiQDP697uwiHHX8xsx5gXx64me/h3XNjJR/BdKDKw==", "7016a462-7651-478d-b418-6c292cd24fd2", "fatmanuraltin" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" },
                    { "f8277277-393d-441f-a66f-b25ea2a453f6", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c5ad1842-eecb-493e-b281-d88881c07e81", "Deniz", "Çoban", "DENIZCOBAN@EXAMPLE.COM", "DENIZCOBAN", "AQAAAAIAAYagAAAAEE9mU5DiPt4pQs+5CKCMI9yBd8yFekqFcBhQJbKHKxf2j4mlwFnS5SCqAvumV1poiA==", "a6359c04-e761-4280-add6-fe54f7fa2a2a", "denizcoban" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b67a3056-deaf-48a9-9261-8480b49b1889", "sedenkaban@example.com", "Seden", "Kaban", "SEDENKABAN@EXAMPLE.COM", "SEDENKABAN", "AQAAAAIAAYagAAAAEJdjToZT5tLnMroEsAkaLiYIpi7OJLt7rRTCRO1NtwXe3tZp+wqROFB7wb0DOpxwkg==", "afccf848-8eab-4444-b935-f3e1b2278ece", "sedenkaban" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c06429a7-61be-4217-a412-177c41b067c9", "kemalcandan@example.com", "Kemal", "Candan", "KEMALCANDAN@EXAMPLE.COM", "KEMALCANDAN", "AQAAAAIAAYagAAAAEARM2NLtCSj0kChA5C5VhDg6mov1gy24XpYiKfIQ8R8o9bSGJygxpHdyFQnggLW/Mw==", "19e762f3-5104-4724-93ee-0323eca3a54a", "kemalcandan" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4", 0, "6788ecc6-470b-4478-bf22-22e600656a11", "berfukeloglan@example.com", true, "Berfu", "Keloğlan", false, null, "BERFUKELOGLAN@EXAMPLE.COM", "BERFUKELOGLAN", "AQAAAAIAAYagAAAAEJRK1I9E9Ma1wwkSm2AUxQ3QEnHRj3tGIjWuOeXYZeZ14KFdpq1/a5wesiSTzmJJ+g==", null, false, "a357b183-54a1-4728-bebd-5b8420ad3355", false, "berfukeloglan" },
                    { "5", 0, "1b867cee-de8e-4d49-898a-f3dd234e06cf", "cantan@example.com", true, "Can", "Tan", false, null, "CANTAN@EXAMPLE.COM", "CANTAN", "AQAAAAIAAYagAAAAEBKil5mbClmL3m2dZXRkIIL5epeGzcHMhfycarj+SoMTe75CEMr1IaP8Ps9BiGd8Pg==", null, false, "54cfe6ab-1955-4743-b661-c9fa4e1f0873", false, "cantan" },
                    { "6", 0, "c6046ba1-290f-4610-a1c3-597ec681fd3e", "mugepor@example.com", true, "Müge", "Por", false, null, "MUGEPOR@EXAMPLE.COM", "MUGEPOR", "AQAAAAIAAYagAAAAEFkANnpIp2Yh1ZI9OEw3Bh4T+IfmGML4qQYzhYGKqlOi8PL7QUWLnzIr7UmHMTYUPg==", null, false, "6cecd73c-0168-49d5-9580-8c82acdfbdf2", false, "mugepor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f8277277-393d-441f-a66f-b25ea2a453f6", "1" },
                    { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", "2" },
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", "3" },
                    { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", "3" },
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", "4" },
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", "5" },
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", "6" }
                });
        }
    }
}
