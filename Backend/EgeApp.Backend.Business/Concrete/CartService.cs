using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;
using EgeApp.Backend.Shared.Dtos.CartDtos;

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



        public async Task<ResponseDto<NoContent>> InitilaizeCartAsync(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
            return ResponseDto<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ResponseDto<CartDto>> GetCartByUserIdAsync(string? userId)
        {
            Cart cart;

            // Kullanıcı ID varsa, sepeti repository'den al
            if (!string.IsNullOrEmpty(userId))
            {
                cart = await _cartRepository.GetCartAsync(userId);

                // Kullanıcıya ait bir sepet bulunamazsa oluştur
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = userId,
                        CreatedDate = DateTime.Now,
                        CartItems = new List<CartItem>()
                    };

                    await _cartRepository.CreateAsync(cart);
                }
            }
            else
            {
                // Kullanıcı yoksa anonim bir sepet oluştur
                cart = new Cart
                {
                    UserId = null, // Kullanıcı yok
                    CreatedDate = DateTime.Now,
                    CartItems = new List<CartItem>()
                };
            }

            // Sepeti DTO'ya dönüştür
            var cartDto = new CartDto
            {
                Id = cart.Id,
                CreatedDate = cart.CreatedDate,
                UserId = cart.UserId,
                CartItems = cart.CartItems?.Select(item => new CartItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                    ProductName = item.Product.Name,
                    ImageUrl = item.Product.ImageUrl
                }).ToList() ?? new List<CartItemDto>()
            };

            // Her durumda başarıyla bir sepet döndür
            return ResponseDto<CartDto>.Success(cartDto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<CartDto>> GetCartBySessionOrUserIdAsync(HttpContext httpContext, string? userId)
        {
            Cart cart;

            if (!string.IsNullOrEmpty(userId))
            {
                // Kullanıcı oturum açmışsa, kullanıcıya ait sepeti getir
                cart = await _cartRepository.GetCartAsync(userId);

                // Eğer kullanıcıya ait sepet yoksa oluştur
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = userId,
                        CreatedDate = DateTime.Now,
                        CartItems = new List<CartItem>()
                    };

                    await _cartRepository.CreateAsync(cart);
                }
            }
            else
            {
                // Kullanıcı oturum açmamışsa Session üzerinden anonim sepeti al
                var sessionId = httpContext.Session.GetString("CartSessionId");

                if (!string.IsNullOrEmpty(sessionId))
                {
                    cart = await _cartRepository.GetCartAsync(sessionId);
                }
                else
                {
                    // Eğer Session ID yoksa yeni anonim sepet oluştur
                    cart = new Cart
                    {
                        UserId = null,
                        CreatedDate = DateTime.Now,
                        CartItems = new List<CartItem>()
                    };

                    await _cartRepository.CreateAsync(cart);

                    // Yeni anonim sepeti Session'a kaydet
                    httpContext.Session.SetString("CartSessionId", cart.Id.ToString());
                }
            }

            // Sepeti DTO'ya dönüştür
            var cartDto = new CartDto
            {
                Id = cart.Id,
                CreatedDate = cart.CreatedDate,
                UserId = cart.UserId,
                CartItems = cart.CartItems?.Select(item => new CartItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                    ProductName = item.Product.Name,
                    ImageUrl = item.Product.ImageUrl
                }).ToList() ?? new List<CartItemDto>()
            };

            return ResponseDto<CartDto>.Success(cartDto, StatusCodes.Status200OK);
        }


        public async Task AssignAnonymousCartToUser(HttpContext httpContext, string userId)
        {
            // Session üzerinden anonim sepeti al
            var sessionId = httpContext.Session.GetString("CartSessionId");
            if (string.IsNullOrEmpty(sessionId)) return;

            // Anonim sepeti repository'den getir
            var cart = await _cartRepository.GetCartAsync(sessionId);
            if (cart == null) return;

            // Sepet zaten kullanıcıya atanmışsa işlem yapma
            if (!string.IsNullOrEmpty(cart.UserId)) return;

            // Anonim sepeti kullanıcıya ata
            cart.UserId = userId;
            await _cartRepository.UpdateAsync(cart);

            // Session temizle (anonim sepet artık kullanıcıya atanmış durumda)
            httpContext.Session.Remove("CartSessionId");
        }
    }
    
}
