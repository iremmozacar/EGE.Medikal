using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Controllers
{

    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotyfService _notyfService;

        public ProductController(INotyfService notyfService, UserManager<AppUser> userManager)
        {
            _notyfService = notyfService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Gelecekte asenkron işlemler için yer bırakılmıştır.
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await ProductService.GetByIdAsync(id);

            if (!result.IsSucceeded)
            {
                _notyfService.Error("Ürün detayları yüklenemedi.");
                return RedirectToAction("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var cartResult = await CartService.GetCartAsync(user.Id);

                if (!cartResult.IsSucceeded)
                {
                    _notyfService.Error("Sepet bilgileri alınırken bir hata oluştu.");
                    return RedirectToAction("Index");
                }

                ViewBag.CountOfItems = cartResult.Data.CountOfItem;
            }

            return View(result.Data);
        }
        [HttpGet("GetDiscountedProducts")]
        public async Task<IActionResult> GetDiscountedProducts()
        {
            // Asenkron sonucu bekle
            var discountedProducts = await ProductService.GetDiscountedProductsAsync();

            // Hata kontrolü
            if (discountedProducts == null || !discountedProducts.IsSucceeded || discountedProducts.Data == null || !discountedProducts.Data.Any())
            {
                return NotFound("No discounted products found.");
            }

            // Başarılı sonuç döndür
            return Ok(discountedProducts.Data);
        }
    }
}
