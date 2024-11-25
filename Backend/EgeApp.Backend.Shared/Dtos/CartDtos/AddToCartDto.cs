using System;
using System.Text.Json.Serialization;

namespace EgeApp.Backend.Shared.Dtos.CartDtos;

public class AddToCartDto
{
    public int ProductId { get; set; }

    public int Quantity { get; set; } = 1;
    public string UserId { get; set; }
}
