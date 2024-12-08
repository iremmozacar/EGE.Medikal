using System;

namespace EgeApp.Backend.Shared.Dtos.CartDtos;

public class CartDto
{
    public int Id { get; set; } // Sepetin benzersiz ID'si
    public DateTime CreatedDate { get; set; } // Sepetin oluşturulma tarihi
    public string UserId { get; set; } // Kullanıcı ID'si
    public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>(); // Sepet ürünleri

    // Ek işlevsellikler
    public int CountOfItem => CartItems?.Count ?? 0; // Sepetteki toplam ürün sayısı

    public decimal GetTotalPrice()
    {
        return CartItems?.Sum(x => x.Price * x.Quantity) ?? 0; // Sepetin toplam fiyatı
    }
}