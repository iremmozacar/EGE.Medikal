using System;
using System.Text.Json.Serialization;
using EgeApp.Frontend.Mvc.Models.Category;

namespace EgeApp.Frontend.Mvc.Models.Product
{
    public class ProductViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("properties")]
        public string Properties { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("discountedPrice")]
        public decimal? DiscountedPrice { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("mainImage")]
        public string MainImage { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category")]
        public CategoryViewModel Category { get; set; }

        // Medikal ürünler için özel alanlar
        [JsonPropertyName("stockCode")]
        public string StockCode { get; set; }

        [JsonPropertyName("warrantyPeriod")]
        public string WarrantyPeriod { get; set; }

        [JsonPropertyName("isDiscounted")]
        public bool IsDiscounted { get; set; }

        [JsonPropertyName("isFreeShipping")]
        public bool IsFreeShipping { get; set; }

        [JsonPropertyName("isSpecialProduct")]
        public bool IsSpecialProduct { get; set; }

        [JsonPropertyName("isSameDayShipping")]
        public bool IsSameDayShipping { get; set; }

        [JsonPropertyName("isLimitedStock")]
        public bool IsLimitedStock { get; set; }

        [JsonPropertyName("productDescription")]
        public string ProductDescription { get; set; }

        // İlişkili ürünler listesi
        [JsonPropertyName("relatedProducts")]
        public List<ProductViewModel> RelatedProducts { get; set; } // İlişkili ürünler
    }
}