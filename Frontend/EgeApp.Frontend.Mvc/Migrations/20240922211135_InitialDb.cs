using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49bb0905-f559-4d1f-b21d-6f36315a5def", null, "Müşterilerin rolü", "Customer", "CUSTOMER" },
                    { "f7510d57-b162-47fd-a5cb-4ca542ef72e9", null, "Sistemdeki yönetimsel işleri yapmaya yetkili rol", "Admin", "ADMIN" },
                    { "f8277277-393d-441f-a66f-b25ea2a453f6", null, "Sistemdeki her türlü işi yapmaya yetkili rol", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "c5ad1842-eecb-493e-b281-d88881c07e81", "denizcoban@example.com", true, "Deniz", "Çoban", false, null, "DENIZCOBAN@EXAMPLE.COM", "DENIZCOBAN", "AQAAAAIAAYagAAAAEE9mU5DiPt4pQs+5CKCMI9yBd8yFekqFcBhQJbKHKxf2j4mlwFnS5SCqAvumV1poiA==", null, false, "a6359c04-e761-4280-add6-fe54f7fa2a2a", false, "denizcoban" },
                    { "2", 0, "b67a3056-deaf-48a9-9261-8480b49b1889", "sedenkaban@example.com", true, "Seden", "Kaban", false, null, "SEDENKABAN@EXAMPLE.COM", "SEDENKABAN", "AQAAAAIAAYagAAAAEJdjToZT5tLnMroEsAkaLiYIpi7OJLt7rRTCRO1NtwXe3tZp+wqROFB7wb0DOpxwkg==", null, false, "afccf848-8eab-4444-b935-f3e1b2278ece", false, "sedenkaban" },
                    { "3", 0, "c06429a7-61be-4217-a412-177c41b067c9", "kemalcandan@example.com", true, "Kemal", "Candan", false, null, "KEMALCANDAN@EXAMPLE.COM", "KEMALCANDAN", "AQAAAAIAAYagAAAAEARM2NLtCSj0kChA5C5VhDg6mov1gy24XpYiKfIQ8R8o9bSGJygxpHdyFQnggLW/Mw==", null, false, "19e762f3-5104-4724-93ee-0323eca3a54a", false, "kemalcandan" },
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
