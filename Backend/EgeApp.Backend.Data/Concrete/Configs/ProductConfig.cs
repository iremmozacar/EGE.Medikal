using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EgeApp.Backend.Models;
using System;
using System.Collections.Generic;

namespace EgeApp.Backend.Data.Concrete.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Anahtar (Primary Key) ve id'nin otomatik artan olması
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Ürün adı, gerekli ve 250 karakterle sınırlandırılmış
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            // Açıklama, nullable
            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            // Fiyat, gerekli
            builder.Property(x => x.Price)
                .IsRequired();

            // İndirimli fiyat, nullable
            builder.Property(x => x.DiscountedPrice)
                .IsRequired(false);

            // Görsel URL, gerekli
            builder.Property(x => x.ImageUrl)
                .IsRequired();

            // Ürün durumu (Aktiflik), gerekli
            builder.Property(x => x.IsActive)
                .IsRequired();

            // Stok kodu, nullable
            builder.Property(x => x.StockCode)
                .HasMaxLength(100);

            // Garanti süresi, nullable
            builder.Property(x => x.WarrantyPeriod)
                .HasMaxLength(100);

            // İndirimli ürün, ücretsiz kargo, özel ürün vb. alanlar
            builder.Property(x => x.IsDiscounted)
                .IsRequired();
            builder.Property(x => x.IsFreeShipping)
                .IsRequired();
            builder.Property(x => x.IsSpecialProduct)
                .IsRequired();
            builder.Property(x => x.IsSameDayShipping)
                .IsRequired();
            builder.Property(x => x.IsLimitedStock)
                .IsRequired();

            // Kategori ilişkisi (Foreign Key)
            builder.HasOne(x => x.Category)  // Category ile olan ilişki
                .WithMany()  // Eğer Category modelinde bir koleksiyon varsa, bunu kullanabilirsin
                .HasForeignKey(x => x.ProductCategoryId)  // CategoryId property’si foreign key
                .IsRequired();  // Foreign key gerekli

            // Medikal ürünlere özgü alanlar
            builder.Property(x => x.PrescriptionRequired)
                .IsRequired(false);

            builder.Property(x => x.ManufacturingDate)
                .IsRequired(false);

            builder.Property(x => x.ExpirationDate)
                .IsRequired(false);

            builder.Property(x => x.StorageConditions)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.UsageInstructions)
                .HasMaxLength(500)
                .IsRequired(false);

            // Tarih alanlarının varsayılan değerlerini SQLite ile uyumlu hale getirme
            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("date('now')");

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("date('now')");


            // Veritabanına önceden eklenmiş ürün verileri
            var products = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name = "Dorselumber Korse",
                    Price = 1000,
                    Description = "Diz ve sırt destekleyici",
                    Url = "dorselumber-korse",
                    ImageUrl = "http://localhost:5200/images/products/dorselumberkorse.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Devisbiss Oksijen Konsantratörü",
                    Price = 8000,
                    Description = "Profesyonel solunum cihazı",
                    Url = "devisbiss-oksijen-konsantratoru",
                    ImageUrl = "http://localhost:5200/images/products/devisbissoksijen.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 2
                },
                new()
                {
                    Id = 3,
                    Name = "Tam Yüz Maskesi",
                    Price = 500,
                    Description = "Solunum desteği için maske",
                    Url = "tam-yuz-maskesi",
                    ImageUrl = "http://localhost:5200/images/products/tamyuzmaskesi.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 3
                },
                new()
                {
                    Id = 4,
                    Name = "2 Motorlu Hasta Karyolası",
                    Price = 12000,
                    Description = "Hasta bakım için motorlu yatak",
                    Url = "2-motorlu-hasta-karyolasi",
                    ImageUrl = "http://localhost:5200/images/products/motorluhastakaryolasi.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsFreeShipping = true,
                    IsActive = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 2
                },
                new()
                {
                    Id = 5,
                    Name = "W Cura C",
                    Price = 700,
                    Description = "Hızlı tıbbi test malzemesi",
                    Url = "w-cura-c",
                    ImageUrl = "http://localhost:5200/images/products/wcuracdbg.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 5
                },
                new()
                {
                    Id = 6,
                    Name = "Tansiyon Aleti",
                    Price = 500,
                    Description = "Hassas tansiyon ölçer",
                    Url = "tansiyon-aleti",
                    ImageUrl = "http://localhost:5200/images/products/tansiyonaleti.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsLimitedStock = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false, // Ekleme
                    ProductCategoryId = 1
                }
            };
            builder.HasData(products);
            builder.ToTable("Products");
        }
    }
}