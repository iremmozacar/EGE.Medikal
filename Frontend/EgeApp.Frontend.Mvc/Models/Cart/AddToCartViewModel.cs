using System;
using System.Text.Json.Serialization;

namespace EgeApp.Frontend.Mvc.Models.Cart;

public class AddToCartViewModel
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; } = 1;

    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    // [JsonIgnore]
    // public string ReturnUrl { get; set; } = null;
}
