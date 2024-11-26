using EgeApp.Backend.Shared.Dtos.CategoryDtos;

namespace EgeApp.Backend.Shared.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }  // Ürün ID'si
        public string Name { get; set; }  // Ürün adı
        public string Description { get; set; }  // Ürün açıklaması
        public decimal Price { get; set; }  // Ürün fiyatı
        public decimal? DiscountedPrice { get; set; }  // İndirimli fiyat
        public string ImageUrl { get; set; }  // Ürün resim URL'si
        public bool IsActive { get; set; }  // Ürün aktif mi?
        public string? StockCode { get; set; }  // Stok kodu
        public string? WarrantyPeriod { get; set; }  // Garanti süresi
        public bool IsDiscounted { get; set; }  // İndirimli mi?
        public bool? IsFreeShipping { get; set; }  // Ücretsiz kargo mu?
        public bool? IsSpecialProduct { get; set; }  // Özel ürün mü?
        public bool? IsSameDayShipping { get; set; }  // Aynı gün kargo mu?
        public bool? IsLimitedStock { get; set; }  // Sınırlı stok mu?
        public string? Url { get; set; }  // Ürün URL'si
        public string? Brand { get; set; }  // Marka
        public bool IsHome { get; set; }  // Ana sayfada mı?
        public DateTime CreatedDate { get; set; }  // Oluşturulma tarihi
        public DateTime ModifiedDate { get; set; }  // Düzenleme tarihi
        public int ProductCategoryId { get; set; }  // Kategori ID
        public CategoryDto Category { get; set; }  // İlişkili kategori
        public bool? PrescriptionRequired { get; set; }  // Reçete gerekli mi?
        public DateTime? ManufacturingDate { get; set; }  // Üretim tarihi
        public DateTime? ExpirationDate { get; set; }  // SKT
        public string? StorageConditions { get; set; }  // Saklama koşulları
        public string? UsageInstructions { get; set; }  // Kullanım talimatları
    }
}