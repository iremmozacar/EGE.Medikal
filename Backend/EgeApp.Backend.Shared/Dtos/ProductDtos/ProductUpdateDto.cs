using System.ComponentModel.DataAnnotations;

namespace EgeApp.Backend.Shared.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }  // Ürün ID'si
        [Required]
        public string Name { get; set; }  // Ürün adı
        public string Description { get; set; }  // Ürün açıklaması
        [Required]
        public decimal Price { get; set; }  // Ürün fiyatı
        public decimal? DiscountedPrice { get; set; }  // İndirimli fiyat
        public string ImageUrl { get; set; }  // Resim URL'si
        public bool IsActive { get; set; }  // Aktif mi?
        public string? StockCode { get; set; }  // Stok kodu
        public string? WarrantyPeriod { get; set; }  // Garanti süresi
        public bool IsDiscounted { get; set; }  // İndirimli mi?
        public bool? IsFreeShipping { get; set; }  // Ücretsiz kargo mu?
        public bool? IsSpecialProduct { get; set; }  // Özel ürün mü?
        public bool? IsSameDayShipping { get; set; }  // Aynı gün kargo mu?
        public bool? IsLimitedStock { get; set; }  // Sınırlı stok mu?
        public string? Url { get; set; }  // Ürün URL'si
        public string? Brand { get; set; }  // Marka
        public bool IsHome { get; set; }  // Ana sayfa ürünü mü?
        [Required]
        public int ProductCategoryId { get; set; }  // Kategori ID
        public bool? PrescriptionRequired { get; set; }  // Reçete gerekli mi?
        public DateTime? ManufacturingDate { get; set; }  // Üretim tarihi
        public DateTime? ExpirationDate { get; set; }  // SKT
        public string? StorageConditions { get; set; }  // Saklama koşulları
        public string? UsageInstructions { get; set; }  // Kullanım talimatları
    }
}