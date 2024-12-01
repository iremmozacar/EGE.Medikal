using System.ComponentModel.DataAnnotations;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;

namespace EgeApp.Backend.Shared.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }  // Ürün adı (zorunlu)
        public string Description { get; set; }  // Ürün açıklaması
        [Required]
        public decimal Price { get; set; }  // Ürün fiyatı (zorunlu)
        public decimal? DiscountedPrice { get; set; }  // İndirimli fiyat
        public string ImageUrl { get; set; }  // Resim URL'si
        public bool IsActive { get; set; } = true;  // Varsayılan: aktif
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
        public int CategoryId { get; set; }  // Seçili kategori ID
        public IEnumerable<CategoryDto> Categories { get; set; }  // Kategori listesi
    }

}