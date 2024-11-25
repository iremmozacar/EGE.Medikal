using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Properties = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(520), "1" },
                    { 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(520), "2" },
                    { 3, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(520), "3" },
                    { 4, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(530), "4" },
                    { 5, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(530), "5" },
                    { 6, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(530), "6" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2000), "Genel kategori", true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2000), "Genel", "genel" },
                    { 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Telefonlar", true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Telefon", "telefon" },
                    { 3, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Elektronik ürünler", true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Elektronik", "elektronik" },
                    { 4, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Bilgisayarlar", true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Bilgisayar", "bilgisayar" },
                    { 5, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Beyaz Eşyalar", true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2010), "Beyaz Eşya", "beyaz-esya" },
                    { 6, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2020), "Yurt dışından gelen ürünler", false, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2020), "Yurt Dışı", "yurt-disi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2780), "http://localhost:5200/images/products/1.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2780), "IPhone 14", 59000m, "Harika bir telefon", "iphone-14" },
                    { 2, 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2780), "http://localhost:5200/images/products/2.png", true, false, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2780), "IPhone 14 Pro", 69000m, "Bu da harika bir telefon", "iphone-14-pro" },
                    { 3, 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2790), "http://localhost:5200/images/products/3.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2790), "Samsung S23", 49000m, "İdare eder", "samsung-s23" },
                    { 4, 2, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2790), "http://localhost:5200/images/products/4.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2790), "Xaomi Note 4", 39000m, "Harika bir telefon", "xaomi-note-4" },
                    { 5, 4, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2800), "http://localhost:5200/images/products/5.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2800), "MacBook Air M2", 52000m, "M2nin gücü", "macbook-air-m2" },
                    { 6, 4, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2800), "http://localhost:5200/images/products/6.png", true, false, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2800), "MacBook Pro M3", 79000m, "16 Gb ram", "macbook-pro-m3" },
                    { 7, 5, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2800), "http://localhost:5200/images/products/7.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2810), "Vestel Çamaşır Makinesi X65", 19000m, "Akıllı makine", "vestel-camasir-makinesi-x65" },
                    { 8, 5, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2810), "http://localhost:5200/images/products/8.png", true, false, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2810), "Arçelik Çamaşır Makinesi A-4", 21000m, "Süper hızlı makine", "arcelik-camasir-makinesi-a-4" },
                    { 9, 3, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2810), "http://localhost:5200/images/products/9.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2810), "Hoop Dijital Radyo X96", 1250m, "Klasik radyo keyfi", "hoop-dijital-radyo-x96" },
                    { 10, 3, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2820), "http://localhost:5200/images/products/10.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2820), "Xaomi Dijital Baskül", 2100m, "Kilonuzu kontrol edin", "xaomi-dijital-baskul" },
                    { 11, 3, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2820), "http://localhost:5200/images/products/11.png", true, true, new DateTime(2024, 11, 25, 21, 9, 15, 497, DateTimeKind.Local).AddTicks(2820), "Blaupunkt AC69 Led TV", 9800m, "Android tv", "blaupunkt-ac69-led-tv" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
