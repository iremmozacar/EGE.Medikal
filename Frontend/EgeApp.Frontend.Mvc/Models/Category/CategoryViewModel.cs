using System;
using System.Text.Json.Serialization;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } // Görsel URL'si için string türünde özellik

        [JsonPropertyName("url")]
        public string Url { get; set; } // Kategori URL'si

        [JsonPropertyName("description")]
        public string? Description { get; set; } // Opsiyonel açıklama

        [JsonPropertyName("productcount")]
        public int ProductCount { get; set; } // Kategoriye bağlı ürün sayısı
    }
}
