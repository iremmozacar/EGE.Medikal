using System;
using System.Text.Json.Serialization;

namespace EgeApp.Frontend.Mvc.Models.Category;

public class CategoryViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
    public int? ParentId { get; set; }
    public List<CategoryViewModel> Children { get; set; }
}
