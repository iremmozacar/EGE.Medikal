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

            // İndirimli ürün
            builder.Property(x => x.IsDiscounted)
                .IsRequired();

            // Ücretsiz kargo
            builder.Property(x => x.IsFreeShipping)
                .IsRequired(false);

            // Özel ürün
            builder.Property(x => x.IsSpecialProduct)
                .IsRequired(false);

            // Aynı gün kargo
            builder.Property(x => x.IsSameDayShipping)
                .IsRequired(false);

            // Ana sayfa ürünü
            builder.Property(x => x.IsHome)
                .IsRequired();

            // Marka
            builder.Property(x => x.Brand)
                .HasMaxLength(100)
                .IsRequired(false);

            // URL
            builder.Property(x => x.Url)
                .HasMaxLength(250)
                .IsRequired(false);

            // Tarih alanlarının varsayılan değerlerini SQLite ile uyumlu hale getirme
            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("date('now')");

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("date('now')");

            // Kategori ilişkisi (Foreign Key)
            builder.HasOne(x => x.Category)  // Category ile olan ilişki
                .WithMany(x => x.Products)  // Category içinde Products koleksiyonu
                .HasForeignKey(x => x.CategoryId)  // Foreign key
                .IsRequired();

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
                    Brand = "KorseMarka",
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false,
                    IsDiscounted = true,
                    CategoryId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Devisbiss Oksijen Konsantratörü",
                    Price = 8000,
                    Description = "Profesyonel solunum cihazı",
                    Url = "devisbiss-oksijen-konsantratoru",
                    ImageUrl = "http://localhost:5200/images/products/devisbissoksijen.webp",
                    Brand = "SolunumMarka",
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = true,
                    IsSameDayShipping = true,
                    IsSpecialProduct = false,
                    IsDiscounted = false,
                    CategoryId = 2
                },
                new()
                {
                    Id = 3,
                    Name = "Tam Yüz Maskesi",
                    Price = 500,
                    Description = "Solunum desteği için maske",
                    Url = "tam-yuz-maskesi",
                    ImageUrl = "http://localhost:5200/images/products/tamyuzmaskesi.webp",
                    Brand = "MaskeMarka",
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsFreeShipping = false,
                    IsSameDayShipping = true,
                    IsSpecialProduct = true,
                    IsDiscounted = false,
                    CategoryId = 3
                }
            };

            builder.HasData(products);
            builder.ToTable("Products");
        }
    }
}