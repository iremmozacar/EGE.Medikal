using System;
using Microsoft.AspNetCore.Http.HttpResults;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;

namespace EgeApp.Backend.Business.Abstract
{
    public interface ICartService
    {
        Task<ResponseDto<NoContent>> InitilaizeCartAsync(string userId);
        Task<ResponseDto<Cart>> GetCartByUserIdAsync(string userId);
        Task<ResponseDto<NoContent>> AddToCartAsync(string userId, int productId, int quantity);
    }
}
