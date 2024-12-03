using Microsoft.AspNetCore.Mvc;

namespace EgeApp.Frontend.Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using AspNetCoreHero.ToastNotification.Abstractions;
    using EgeApp.Frontend.Mvc.Models.Product;
    using EgeApp.Frontend.Mvc.Services;
    using EgeApp.Frontend.Mvc.Data.Entities;
    using EgeApp.Frontend.Mvc.Models.Cart;

    public class ShopController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotyfService _notyfService;
        public ShopController(INotyfService notyfService, UserManager<AppUser> userManager )
        {
            _notyfService = notyfService;
            _userManager = userManager;
           
        }

        // Ürünleri listele
        public async Task<IActionResult> Index()
        {
            // ProductService'den ürünleri alıyoruz
            var productsResponse = await ProductService.GetAllAsync();

            if (!productsResponse.IsSucceeded || productsResponse.Data == null)
            {
                // Eğer API çağrısı başarısızsa veya veri boşsa hata mesajı döndür
                _notyfService.Error("Ürünler yüklenirken bir hata oluştu.");
                return View(new List<ProductListViewModel>()); // Boş bir liste döndür
            }

            // Gelen veriyi ProductListViewModel'e dönüştür
            var productList = productsResponse.Data.Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                DiscountedPrice = p.DiscountedPrice,
                ImageUrl = p.ImageUrl,
                IsActive = p.IsActive,
                IsFreeShipping = p.IsFreeShipping
            }).ToList();

            return View(productList);
        }



        // Sepete ekleme işlemi
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmamışsa oturumda sakla ve giriş sayfasına yönlendir
                HttpContext.Session.SetInt32("ProductId", productId);
                HttpContext.Session.SetInt32("Quantity", quantity);
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart/AddToCartAfterLogin" });
            }

            // Kullanıcı bilgilerini al
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);

            // Sepete ekleme modeli
            var addToCartModel = new AddToCartViewModel
            {
                ProductId = productId,
                Quantity = quantity,
                UserId = userId
            };

            // Sepete ekle
            var result = await CartService.AddToCartAsync(addToCartModel);

            if (result.IsSucceeded)
            {
                _notyfService.Success("Ürün başarıyla sepete eklendi!");
            }
            else
            {
                _notyfService.Error(result.Error ?? "Sepete ekleme sırasında bir hata oluştu.");
            }

            return RedirectToAction("Index");
        }
    }
}
