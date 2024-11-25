using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;

namespace EgeApp.Backend.Business.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ResponseDto<NoContent>> AddToCartAsync(string userId, int productId, int quantity)
        {
            Cart cart = await _cartRepository.GetAsync(x => x.UserId == userId, source => source.Include(x => x.CartItems));
            if (cart == null)
            {
                return ResponseDto<NoContent>.Fail("Kullanıcıya ait bir sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            //Eğer sepete eklenmeye çalışılan ürün daha önceden sepette varsa adedi arttırılacak, yoksa eklenecek.
            var index = cart.CartItems.FindIndex(x => x.ProductId == productId);
            if (index < 0)//Eğer ürün sepette yoksa
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.Id
                });
            }
            else//Eğer ürün sepette zaten varsa
            {
                cart.CartItems[index].Quantity = quantity;
            }
            await _cartRepository.UpdateAsync(cart);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<Cart>> GetCartByUserIdAsync(string userId)
        {
            var cart = await _cartRepository.GetAsync(
                x => x.UserId == userId,
                source => source
                    .Include(x => x.CartItems)
                    .ThenInclude(y => y.Product)
            );
            if (cart == null)
            {
                return ResponseDto<Cart>.Fail("Kullanıcıya ait bir sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            return ResponseDto<Cart>.Success(cart, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContent>> InitilaizeCartAsync(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
            return ResponseDto<NoContent>.Success(StatusCodes.Status201Created);
        }
    }
}
