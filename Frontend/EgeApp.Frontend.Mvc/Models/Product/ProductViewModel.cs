using System;
using System.Text.Json.Serialization;
using EgeApp.Frontend.Mvc.Models.Category;

namespace EgeApp.Frontend.Mvc.Models.Product;

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

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("isHome")]
    public bool IsHome { get; set; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public CategoryViewModel Category { get; set; }
}
