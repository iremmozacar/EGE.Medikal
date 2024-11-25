using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Models.Product;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin, Admin")]
    public class ProductController : Controller
    {
        private readonly INotyfService _notyfService;

        public ProductController(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }

        [Authorize(Roles = "Super Admin, Admin")]
        public async Task<IActionResult> Index()
        {
            var result = await ProductService.GetAllAsync();
            if (!result.IsSucceeded)
            {
                ViewData["Error"] = result.Error;
                return Redirect("/home/error");
            }
            return View(result.Data);
        }
        [Authorize(Roles = "Super Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await CategoryService.GetSelectListItemsAsync();
            if (!result.IsSucceeded)
            {
                ViewData["Error"] = result.Error;
                return Redirect("/home/error");
            }
            var model = new ProductCreateViewModel
            {
                Categories = result.Data
            };
            return View(model);
        }
        [Authorize(Roles = "Super Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await ProductService.CreateAsync(model);
                if (!result.IsSucceeded)
                {
                    TempData["Error"] = result.Error;
                    return Redirect("/home/error");
                }
                _notyfService.Success("Ürün başarıyla oluşturuldu");
                return RedirectToAction("Index");


            }
            var resultCategories = await CategoryService.GetSelectListItemsAsync();
            if (!resultCategories.IsSucceeded)
            {
                TempData["Error"] = resultCategories.Error;
                return Redirect("/home/error");
            }
            model.Categories = resultCategories.Data;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await ProductService.GetByIdAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return Redirect("/home/error");
            }
            ProductEditViewModel model = new()
            {
                Id = result.Data.Id,
                CategoryId = result.Data.CategoryId,
                ImageUrl = result.Data.ImageUrl,
                IsActive = result.Data.IsActive,
                IsHome = result.Data.IsHome,
                Name = result.Data.Name,
                Price = result.Data.Price,
                Properties = result.Data.Properties
            };
            var resultCategories = await CategoryService.GetSelectListItemsAsync();
            if (!resultCategories.IsSucceeded)
            {
                TempData["Error"] = resultCategories.Error;
                return Redirect("/home/error");
            }
            model.Categories = resultCategories.Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await ProductService.UpdateAsync(model);
                if (!result.IsSucceeded)
                {
                    ViewData["Error"] = result.Error;
                    return Redirect("/home/error");
                };
                _notyfService.Success("Ürün başarıyla güncellendi");
                return RedirectToAction("Index");
            }
            var resultCategories = await CategoryService.GetSelectListItemsAsync();
            if (!resultCategories.IsSucceeded)
            {
                TempData["Error"] = resultCategories.Error;
                return Redirect("/home/error");
            }
            model.Categories = resultCategories.Data;
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProductService.DeleteAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return Redirect("/home/error");
            };
            _notyfService.Success("Ürün başarıyla silindi");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await ProductService.UpdateIsActiveAsync(id);
            if (!result.IsSucceeded)
            {
                ViewData["Error"] = result.Error;
                return Redirect("/home/error");
            };
            return Json(result.Data.IsActive);
        }

        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var result = await ProductService.UpdateIsHomeAsync(id);
            if (!result.IsSucceeded)
            {
                ViewData["Error"] = result.Error;
                return Redirect("/home/error");
            };
            return Json(result.Data.IsHome);
        }
    }
}
