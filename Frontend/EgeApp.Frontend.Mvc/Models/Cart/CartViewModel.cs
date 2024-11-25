using System;
using System.Text.Json.Serialization;

namespace EgeApp.Frontend.Mvc.Models.Cart;

public class CartViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("cartItems")]
    public List<CartItemViewModel> CartItems { get; set; }

    public int CountOfItem { get { return CartItems.Count; } }

    public decimal GetTotalPrice()
    {
        return CartItems.Sum(x => x.Product.Price * x.Quantity);
    }
}
