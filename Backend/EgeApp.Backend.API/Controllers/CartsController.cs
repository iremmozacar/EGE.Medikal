using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Shared.Dtos.CartDtos;
using EgeApp.Backend.Shared.Helpers;

namespace EgeApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : CustomControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartsController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CartCreateDto cartCreateDto)
        {
            var response = await _cartService.InitilaizeCartAsync(cartCreateDto.UserId);
            return CreateActionResult(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            // Servis katmanından kullanıcı sepetini al
            var response = await _cartService.GetCartByUserIdAsync(userId);

            // Eğer işlem başarısızsa uygun bir hata yanıtı döndür
            if (!response.IsSucceeded)
            {
                return NotFound(new { Message = response.Error });
            }

            // Başarılı yanıt ve sepet verisini döndür
            return Ok(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartDto addToCartDto)
        {
            var response = await _cartService.AddToCartAsync(addToCartDto.UserId, addToCartDto.ProductId, addToCartDto.Quantity);
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(ChangeQuantityDto changeQuantityDto)
        {
            var response = await _cartItemService.ChangeQuantityAsync(changeQuantityDto.CartItemId, changeQuantityDto.Quantity);
            return CreateActionResult(response);
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> Count(int cartId)
        {
            var response = await _cartItemService.CountAsync(cartId);
            return CreateActionResult(response);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteItem(int cartItemId)
        {
            var response = await _cartItemService.DeleteCartItemAsync(cartItemId);
            return CreateActionResult(response);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            var response = await _cartItemService.ClearCartAsync(cartId);
            return CreateActionResult(response);
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> GetCartItem(int cartItemId)
        {
            var response = await _cartItemService.GetCartItemAsync(cartItemId);
            return CreateActionResult(response);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignAnonymousCartToUser(string userId)
        {
            await _cartService.AssignAnonymousCartToUser(HttpContext, userId);
            return Ok();
        }
    }

}
