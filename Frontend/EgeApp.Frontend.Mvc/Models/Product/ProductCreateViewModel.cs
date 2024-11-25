using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgeApp.Frontend.Mvc.Models.Product;

public class ProductCreateViewModel
{
    [JsonPropertyName("name")]
    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
    public string Name { get; set; }

    [JsonPropertyName("isActive")]
    [Display(Name = "Aktif mi?")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("properties")]
    [Display(Name = "Özellikler")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
    public string Properties { get; set; }

    [JsonPropertyName("price")]
    [Display(Name = "Fiyat")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
    public decimal? Price { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("isHome")]
    [Display(Name = "Anasayfa Ürünü mü?")]
    public bool IsHome { get; set; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [Display(Name = "Kategori seç")]
    public List<SelectListItem> Categories { get; set; }
    [Display(Name = "Ürün Resmi")]
    [Required(ErrorMessage = "Resim seçmeden ürün kaydedemezsiniz!")]
    public IFormFile Image { get; set; }

}
