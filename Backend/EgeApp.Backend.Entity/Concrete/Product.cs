using System;
using System.ComponentModel.DataAnnotations;

namespace EgeApp.Backend.Models
{
    public class Product
    {
        public int Id { get; set; } // Ürün ID'si
        public string Name { get; set; } // Ürün adı
        public string Description { get; set; } // Ürün açıklaması
        public decimal Price { get; set; } // Ürün fiyatı
        public decimal? DiscountedPrice { get; set; } // İndirimli ürün fiyatı
        public string ImageUrl { get; set; } // Ürün resim URL'si
        public bool IsActive { get; set; } // Ürün aktif mi?
        public string? StockCode { get; set; } // Özel stok kodu
        public string? WarrantyPeriod { get; set; } // Ürün garanti süresi
        public bool IsDiscounted { get; set; } // Ürün indirimli mi?
        public bool? IsFreeShipping { get; set; } // Ürün ücretsiz kargo ile mi?
        public bool? IsSpecialProduct { get; set; } // Özel ürün mü?
        public bool? IsSameDayShipping { get; set; } // Aynı gün kargo mu?
        public bool? IsLimitedStock { get; set; } // Sınırlı stoklu ürün mü?

        // Ürün için kategori ID'si (Yeni isim kullanıldı)
        public int ProductCategoryId { get; set; } // İsim değiştirildi

        // Ürün ile ilişkilendirilmiş kategori
        public Category Category { get; set; }  // Category ile ilişki

        // Medikal ürünlere özgü ek bilgiler
        public bool? PrescriptionRequired { get; set; } // Reçeteli ürün mü? Nullable
        public DateTime? ManufacturingDate { get; set; } // Üretim tarihi
        public DateTime? ExpirationDate { get; set; } // Son kullanma tarihi
        public string? StorageConditions { get; set; } // Saklama koşulları
        public string? UsageInstructions { get; set; } // Kullanım talimatları

        // Yeni eklenen alanlar
        public string? Url { get; set; }  // Ürün URL'si
        public string? Brand { get; set; }  // Marka
        public bool IsHome { get; set; }  // Ana sayfa özelliği
        public DateTime CreatedDate { get; set; }  // Ürün oluşturulma tarihi
        public DateTime ModifiedDate { get; set; }  // Ürün son düzenleme tarihi
    }
}