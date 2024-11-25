using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Models;
using EgeApp.Frontend.Mvc.Models.Product;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Controllers;

public class HomeController : Controller
{

    private readonly UserManager<AppUser> _userManager;

    public HomeController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {

        var resultCategories = await CategoryService.GetActives();
        if (!resultCategories.IsSucceeded)
        {
            TempData["Error"] = resultCategories.Error;
            return RedirectToAction("Error", "Home");
        }
        var resultProducts = await ProductService.GetHomesAsync();
        if (!resultProducts.IsSucceeded)
        {
            TempData["Error"] = resultCategories.Error;
            return RedirectToAction("Error", "Home");
        }
        ProductsCategoriesViewModel model = new()
        {
            CategoryList = resultCategories.Data,
            ProductList = resultProducts.Data
        };
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            var cartResult = await CartService.GetCartAsync(userId);
            // if (!cartResult.IsSucceeded)
            // {
            //     ViewData["Error"] = cartResult.Error;
            //     return RedirectToAction("Error", "Home");
            // }
            ViewBag.CountOfItems = cartResult.IsSucceeded ? cartResult.Data.CountOfItem : 0;
        }
        return View(model);
    }
    public IActionResult Error()
    {
        return View();
    }
}
