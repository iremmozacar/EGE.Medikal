using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Models.Cart;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotyfService _notyfService;

        public CartController(UserManager<AppUser> userManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            var cartResult = await CartService.GetCartAsync(userId);

            if (!cartResult.IsSucceeded)
            {
                return RedirectToAction("Error", "Home");
            }
            var cart = cartResult.Data;
            ViewBag.CountOfItems = cart.CountOfItem;
            return View(cart);
        }

        public async Task<IActionResult> AddToCartAfterLogin()
        {
            var productId = HttpContext.Session.GetInt32("ProductId");
            var quantity = HttpContext.Session.GetInt32("Quantity");
            if (productId.HasValue && quantity.HasValue)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var userId = await _userManager.GetUserIdAsync(user);
                var model = new AddToCartViewModel
                {
                    UserId = userId,
                    ProductId = productId.Value,
                    Quantity = quantity.Value
                };
                return RedirectToAction("AddToCart", model);
            }
            _notyfService.Error("Bir sorun oluştu, yeniden deneyiniz!");
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> AddToCart(AddToCartViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetInt32("ProductId", model.ProductId);
                HttpContext.Session.SetInt32("Quantity", model.Quantity);
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart/AddToCartAfterLogin" });
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            model.UserId = userId;
            var result = await CartService.AddToCartAsync(model);
            if (!result.IsSucceeded)
            {
                _notyfService.Error("Bir hata oluştu, ürün sepete eklenemedi!");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            var result = await CartService.ChangeQuantityAsync(cartItemId, quantity, userId);
            if (!result.IsSucceeded)
            {
                _notyfService.Error("Bir hata oluştu");
                return RedirectToAction("Index");
            }
            return Json(result.Data);
        }

        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var result = await CartService.DeleteCartItemAsync(id);
            if (!result.IsSucceeded)
            {
                _notyfService.Error("Bir hata oluştu");
            }
            _notyfService.Success("Ürün sepetinizden başarıyla kaldırıldı");
            return RedirectToAction("Index");

        }
    }
}


