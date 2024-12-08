using System;
using EgeApp.Backend.Shared.Dtos.ProductDtos;

namespace EgeApp.Backend.Shared.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int CartId { get; set; }
    public int Quantity { get; set; }
}