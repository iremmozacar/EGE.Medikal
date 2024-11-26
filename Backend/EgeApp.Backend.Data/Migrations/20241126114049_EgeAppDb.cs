using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgeApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class EgeAppDb : Migration
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    StockCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    WarrantyPeriod = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsDiscounted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSpecialProduct = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSameDayShipping = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLimitedStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriptionRequired = table.Column<bool>(type: "INTEGER", nullable: true),
                    ManufacturingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StorageConditions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    UsageInstructions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
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
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    { 1, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1460), "1" },
                    { 2, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1470), "2" },
                    { 3, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1470), "3" },
                    { 4, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480), "4" },
                    { 5, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480), "5" },
                    { 6, new DateTime(2024, 11, 26, 14, 40, 49, 562, DateTimeKind.Local).AddTicks(1480), "6" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name", "ParentCategoryId", "Url" },
                values: new object[,]
                {
                    { 1, "Ortopedik ürünler", true, "Ortopedik Ürünler", null, "ortopedik-urunler" },
                    { 2, "Solunum cihazları", true, "Solunum Cihazları", null, "solunum-cihazlari" },
                    { 3, "Solunum maskeleri", true, "Solunum Maskeleri", null, "solunum-maskeleri" },
                    { 4, "Hasta bakım ürünleri", true, "Hasta Bakım Ürünleri", null, "hasta-bakim-urunleri" },
                    { 5, "Tıbbi test ve sarf malzemeleri", true, "Tıbbi Test ve Sarf Malzemeleri", null, "tibbi-test-ve-sarf-malzemeleri" },
                    { 6, "Tansiyon ve nabız ölçüm cihazları", true, "Tansiyon ve Nabız Ölçüm Cihazları", null, "tansiyon-ve-nabiz-olcum-cihazlari" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Description", "DiscountedPrice", "ExpirationDate", "ImageUrl", "IsActive", "IsDiscounted", "IsFreeShipping", "IsHome", "IsLimitedStock", "IsSameDayShipping", "IsSpecialProduct", "ManufacturingDate", "ModifiedDate", "Name", "PrescriptionRequired", "Price", "ProductCategoryId", "StockCode", "StorageConditions", "Url", "UsageInstructions", "WarrantyPeriod" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6320), "Diz ve sırt destekleyici", null, null, "http://localhost:5200/images/products/dorselumberkorse.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6330), "Dorselumber Korse", null, 1000m, 1, null, null, "dorselumber-korse", null, null },
                    { 2, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6340), "Profesyonel solunum cihazı", null, null, "http://localhost:5200/images/products/devisbissoksijen.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6340), "Devisbiss Oksijen Konsantratörü", null, 8000m, 2, null, null, "devisbiss-oksijen-konsantratoru", null, null },
                    { 3, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), "Solunum desteği için maske", null, null, "http://localhost:5200/images/products/tamyuzmaskesi.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), "Tam Yüz Maskesi", null, 500m, 3, null, null, "tam-yuz-maskesi", null, null },
                    { 4, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), "Hasta bakım için motorlu yatak", null, null, "http://localhost:5200/images/products/motorluhastakaryolasi.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6350), "2 Motorlu Hasta Karyolası", null, 12000m, 4, null, null, "2-motorlu-hasta-karyolasi", null, null },
                    { 5, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6360), "Hızlı tıbbi test malzemesi", null, null, "http://localhost:5200/images/products/wcuracdbg.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6360), "W Cura C", null, 700m, 5, null, null, "w-cura-c", null, null },
                    { 6, null, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6370), "Hassas tansiyon ölçer", null, null, "http://localhost:5200/images/products/tansiyonaleti.webp", true, false, true, true, false, true, false, null, new DateTime(2024, 11, 26, 14, 40, 49, 563, DateTimeKind.Local).AddTicks(6370), "Tansiyon Aleti", null, 500m, 6, null, null, "tansiyon-aleti", null, null }
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
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
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
