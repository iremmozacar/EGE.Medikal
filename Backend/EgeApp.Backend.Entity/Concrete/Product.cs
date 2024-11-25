using EgeApp.Backend.Entity.Abstract;

namespace EgeApp.Backend.Entity.Concrete
{
    public class Product : BaseEntity
    {
        public string Properties { get; set; } // Ürün özellikleri
        public decimal Price { get; set; } // Ürün fiyatı
        public decimal? DiscountedPrice { get; set; } // İndirimli fiyat (nullable)
        public int? Stock { get; set; } // Stok miktarı
        public string? Brand { get; set; } // Marka
        public string ImageUrl { get; set; } // Ürün görseli URL
        public bool IsHome { get; set; } // Ana sayfada görünür mü
        public int? WarrantyPeriod { get; set; } // Garanti süresi
        public string? ProductionPlace { get; set; } // Üretim yeri
        public int CategoryId { get; set; } // Kategori ID'si
        public Category Category { get; set; } // İlişkili kategori
        public string? Description { get; set; } // Ürün açıklaması (nullable)
    }
}
