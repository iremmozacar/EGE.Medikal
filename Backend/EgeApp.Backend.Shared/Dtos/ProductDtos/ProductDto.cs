using System;
using System.Collections.Generic;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;

namespace EgeApp.Backend.Shared.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; } // Ürün ID'si
        public string Name { get; set; } // Ürün adı
        public string Description { get; set; } // Ürün açıklaması
        public decimal Price { get; set; } // Ürün fiyatı
        public decimal? DiscountedPrice { get; set; } // İndirimli fiyat
        public int SalesCount { get; set; } // Satış sayısı
        public string ImageUrl { get; set; } // Resim URL'si
        public bool IsActive { get; set; } // Ürün aktif mi?
        public bool IsDiscounted { get; set; } // İndirimli mi?
        public bool? IsFreeShipping { get; set; } // Ücretsiz kargo mu?
        public bool? IsSpecialProduct { get; set; } // Özel ürün mü?
        public bool? IsSameDayShipping { get; set; } // Aynı gün kargo mu?
        public int CategoryId { get; set; } // Kategori ID (Yeni eklenen)
        public string? Url { get; set; } // Ürün URL'si
        public string? Brand { get; set; } // Marka
        public bool IsHome { get; set; } // Ana sayfa ürünü mü?
        public DateTime CreatedDate { get; set; } // Oluşturulma tarihi
        public DateTime ModifiedDate { get; set; } // Güncellenme tarihi
        public CategoryDto Category { get; set; } // Kategori bilgileri
        public IEnumerable<CategoryDto> CategoryList { get; set; } // Kategori listesi (Opsiyonel)
    }
}
