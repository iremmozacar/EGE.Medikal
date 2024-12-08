using System;

namespace EgeApp.Backend.Shared.Dtos.CartDtos;

public class CartItemDto
{
    public int ProductId { get; set; } // İlgili ürünün ID'si
    public string ProductName { get; set; } // Ürün adı
    public string ImageUrl { get; set; } // Ürün görseli
    public decimal Price { get; set; } // Ürün fiyatı
    public int Quantity { get; set; } // Ürün adedi
}