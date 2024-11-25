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
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
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
                    Properties = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductionPlace = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
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
                    { 1, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6000), "1" },
                    { 2, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6010), "2" },
                    { 3, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6010), "3" },
                    { 4, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6010), "4" },
                    { 5, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6020), "5" },
                    { 6, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(6020), "6" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "ParentCategoryId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8430), "Uyku ve solunum cihazları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8430), "Uyku ve Solunum", null, "uyku-ve-solunum" },
                    { 8, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8470), "Tekerlekli sandalye çeşitleri", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8470), "Tekerlekli Sandalyeler", null, "tekerlekli-sandalyeler" },
                    { 11, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8490), "Konuşma cihazları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8490), "Konuşma Cihazları", null, "konusma-cihazlari" },
                    { 12, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8490), "Masaj ve muayene masaları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8490), "Masaj - Muayene Masaları", null, "masaj-muayene-masalari" },
                    { 13, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Çeşitli pusetler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Pusetler", null, "pusetler" },
                    { 14, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Yatan hastalar için ürünler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Yatan Hasta", null, "yatan-hasta" },
                    { 19, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8520), "Engelsiz yaşam için ürünler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8520), "Engelsiz Ürünler", null, "engelsiz-urunler" },
                    { 2, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8440), "Oksijen konsantratörleri", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8440), "Konsantratörler", 1, "konsantratorler" },
                    { 3, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8450), "Aspiratör cihazları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8450), "Aspiratör Cihazları", 1, "aspirator-cihazlari" },
                    { 4, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8450), "Oksimetre cihazları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8450), "Oksimetre", 1, "oksimetre" },
                    { 5, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8460), "Oksijen tüpleri ve yardımcı aletler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8460), "Oksijen Tüpü ve Yardımcı Aletleri", 1, "oksijen-tupu-yardimci-aletler" },
                    { 6, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8460), "Oksijen kanülleri", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8460), "Kanüller", 1, "kanuller" },
                    { 7, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8470), "Pap cihazları ve ürünleri", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8470), "Pap Ürünleri", 1, "pap-urunleri" },
                    { 9, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8480), "Banyo ve tuvalet kullanımına uygun tekerlekli sandalyeler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8480), "Banyo ve Tuvalet Tekerlekli Sandalyeleri", 8, "banyo-ve-tuvalet-tekerlekli-sandalyeleri" },
                    { 10, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8480), "Günlük kullanım için tekerlekli sandalyeler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8480), "Günlük Kullanım Tekerlekli Sandalyeler", 8, "gunluk-kullanim-tekerlekli-sandalyeler" },
                    { 15, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Motorlu hasta karyolası", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8500), "Hasta Karyolası", 14, "hasta-karyolasi" },
                    { 16, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8510), "Hasta yatakları", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8510), "Hasta Yatakları", 14, "hasta-yataklari" },
                    { 17, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8510), "Yatan hastalar için bezler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8510), "Hasta Bezleri", 14, "hasta-bezleri" },
                    { 18, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8520), "Yatan hastalar için yardımcı aletler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8520), "Yardımcı Aletler", 14, "yardimci-aletler" },
                    { 20, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8530), "Baston ve kanedyen çeşitleri", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8530), "Baston/Kanedyen", 19, "baston-kanedyen" },
                    { 21, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8530), "Yürütücü cihazlar ve walkerlar", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8530), "Yürütücü ve Wolker", 19, "yurutucu-ve-wolker" },
                    { 22, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8540), "Engelsiz yaşam için ek ürünler", true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(8540), "Ek Ürünler", 19, "ek-urunler" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDate", "Description", "DiscountedPrice", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "ProductionPlace", "Properties", "Stock", "Url", "WarrantyPeriod" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(9960), null, null, "http://localhost:5200/images/products/dorselumberkorse.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(9960), "Dorselumber Korse", 1000m, null, "Diz ve sırt destekleyici", null, "dorselumber-korse", null },
                    { 2, null, 2, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(9970), null, null, "http://localhost:5200/images/products/devisbissoksijen.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 764, DateTimeKind.Local).AddTicks(9970), "Devisbiss Oksijen Konsantratörü", 8000m, null, "Profesyonel solunum cihazı", null, "devisbiss-oksijen-konsantratoru", null },
                    { 3, null, 3, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local), null, null, "http://localhost:5200/images/products/tamyuzmaskesi.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local), "Tam Yüz Maskesi", 500m, null, "Solunum desteği için maske", null, "tam-yuz-maskesi", null },
                    { 4, null, 4, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(10), null, null, "http://localhost:5200/images/products/motorluhastakaryolasi.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(10), "2 Motorlu Hasta Karyolası", 12000m, null, "Hasta bakım için motorlu yatak", null, "2-motorlu-hasta-karyolasi", null },
                    { 5, null, 5, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(20), null, null, "http://localhost:5200/images/products/wcuracdbg.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(20), "W Cura C", 700m, null, "Hızlı tıbbi test malzemesi", null, "w-cura-c", null },
                    { 6, null, 6, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(30), null, null, "http://localhost:5200/images/products/tansiyonaleti.webp", true, true, new DateTime(2024, 11, 25, 23, 33, 59, 765, DateTimeKind.Local).AddTicks(30), "Tansiyon Aleti", 500m, null, "Hassas tansiyon ölçer", null, "tansiyon-aleti", null }
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
