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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await ProductService.GetAllAsync();
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error ?? "Ürünler yüklenirken bir hata oluştu.";
                return RedirectToAction("Error", "Home");
            }
            return View(result.Data);
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> Create()
        {
            var categories = await CategoryService.GetSelectListItemsAsync();
            if (!categories.IsSucceeded)
            {
                TempData["Error"] = categories.Error ?? "Kategoriler yüklenemedi.";
                return RedirectToAction("Error", "Home");
            }

            var model = new ProductCreateViewModel
            {
                Categories = categories.Data
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Lütfen tüm gerekli alanları doldurun.");
                return await ReloadCreateModelWithCategories(model);
            }

            var result = await ProductService.CreateAsync(model);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error ?? "Ürün oluşturulamadı.";
                return await ReloadCreateModelWithCategories(model);
            }

            _notyfService.Success("Ürün başarıyla oluşturuldu.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await ProductService.GetByIdAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error ?? "Ürün bulunamadı.";
                return RedirectToAction("Error", "Home");
            }

            var model = new ProductEditViewModel
            {
                Id = result.Data.Id,
                Name = result.Data.Name,
                Properties = result.Data.Properties,
                Price = result.Data.Price,
                IsActive = result.Data.IsActive,
                IsHome = result.Data.IsHome,
                CategoryId = result.Data.CategoryId,
                ImageUrl = result.Data.ImageUrl
            };

            var categories = await CategoryService.GetSelectListItemsAsync();
            if (!categories.IsSucceeded)
            {
                TempData["Error"] = categories.Error ?? "Kategoriler yüklenemedi.";
                return RedirectToAction("Error", "Home");
            }

            model.Categories = categories.Data;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Lütfen tüm gerekli alanları doldurun.");
                return await ReloadEditModelWithCategories(model);
            }

            var result = await ProductService.UpdateAsync(model);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error ?? "Ürün güncellenemedi.";
                return await ReloadEditModelWithCategories(model);
            }

            _notyfService.Success("Ürün başarıyla güncellendi.");
            return RedirectToAction("Index");
        }

        private async Task<IActionResult> ReloadCreateModelWithCategories(ProductCreateViewModel model)
        {
            var categories = await CategoryService.GetSelectListItemsAsync();
            if (!categories.IsSucceeded)
            {
                TempData["Error"] = categories.Error ?? "Kategoriler yüklenemedi.";
                return RedirectToAction("Error", "Home");
            }

            model.Categories = categories.Data;
            return View("Create", model);
        }

        private async Task<IActionResult> ReloadEditModelWithCategories(ProductEditViewModel model)
        {
            var categories = await CategoryService.GetSelectListItemsAsync();
            if (!categories.IsSucceeded)
            {
                TempData["Error"] = categories.Error ?? "Kategoriler yüklenemedi.";
                return RedirectToAction("Error", "Home");
            }

            model.Categories = categories.Data;
            return View("Edit", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProductService.DeleteAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error ?? "Ürün silinemedi.";
                return RedirectToAction("Error", "Home");
            }

            _notyfService.Success("Ürün başarıyla silindi.");
            return RedirectToAction("Index");
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

    }
}
