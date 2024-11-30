using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Models;
using EgeApp.Frontend.Mvc.Models.Product;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Kategorileri al
                var resultCategories = await CategoryService.GetActives();
                if (resultCategories == null || !resultCategories.IsSucceeded)
                {
                    TempData["Error"] = resultCategories?.Error ?? "An error occurred while fetching categories.";
                    return RedirectToAction("Error", "Home");
                }

                // Ürünleri al
                var resultProducts = await ProductService.GetHomesAsync();
                if (resultProducts == null || !resultProducts.IsSucceeded)
                {
                    TempData["Error"] = resultProducts?.Error ?? "An error occurred while fetching products.";
                    return RedirectToAction("Error", "Home");
                }

                // ViewModel'i oluştur
                ProductsCategoriesViewModel model = new()
                {
                    CategoryList = resultCategories.Data,
                    ProductList = resultProducts.Data
                };

                // Kullanıcı giriş yapmışsa sepetteki ürün sayısını al
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (user != null)
                    {
                        var userId = await _userManager.GetUserIdAsync(user);
                        var cartResult = await CartService.GetCartAsync(userId);

                        // Sepet sonucu kontrolü
                        ViewBag.CountOfItems = cartResult?.IsSucceeded == true ? cartResult.Data.CountOfItem : 0;
                    }
                    else
                    {
                        ViewBag.CountOfItems = 0;
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                TempData["Error"] = $"An exception occurred: {ex.Message}";
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}