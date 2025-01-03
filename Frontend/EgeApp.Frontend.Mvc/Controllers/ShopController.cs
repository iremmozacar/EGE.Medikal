using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EgeApp.Frontend.Mvc.Models.Product;
using System.Linq;
using System.Collections.Generic;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Controllers
{
    public class ShopController : Controller
    {
        // Ürünleri listele
        public async Task<IActionResult> Index()
        {
            var productsResponse = await ProductService.GetAllAsync();

            if (!productsResponse.IsSucceeded || productsResponse.Data == null)
            {
                Console.WriteLine("Ürün verisi null geldi veya API çağrısı başarısız oldu.");
                return View(new List<ProductListViewModel>()); // Boş liste döndür
            }

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

            return View(productList); // Varsayılan olarak 'Views/Shop/Index.cshtml' dosyasını yükler
        }

        // Sepete ekleme işlemi
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmamışsa oturumda sakla ve giriş sayfasına yönlendir
                HttpContext.Session.SetInt32("ProductId", productId);
                HttpContext.Session.SetInt32("Quantity", quantity);
                return RedirectToAction("Login", "Account", new { returnUrl = "/Cart/AddToCartAfterLogin" });
            }

            // Sepete ekleme işlemi başarılıysa yönlendir
            TempData["SuccessMessage"] = "Ürün başarıyla sepete eklendi!";
            return RedirectToAction("Index");
        }
    }
}