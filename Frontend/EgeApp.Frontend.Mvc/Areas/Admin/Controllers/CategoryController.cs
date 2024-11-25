using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgeApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin, Admin")]
    public class CategoryController : Controller
    {
        private readonly INotyfService _notyfService;

        public CategoryController(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }

        [Authorize(Roles = "Super Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Kategorileri al
            var response = await CategoryService.GetAllAsync();

            if (!response.IsSucceeded)
            {
                // Hata durumunda uygun aksiyonu al
                TempData["Error"] = response.Error;
                return RedirectToAction("Error", "Home");
            }

            // Kategorilerin listesini al
            var categories = response.Data;

            var model = new CategoryCreateViewModel
            {
                Categories = new SelectList(categories, "Id", "Name") // Kategorileri ViewModel'e aktar
            };

            return View(model);
        }

        [Authorize(Roles = "Super Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Eğer resim varsa, dosyayı kaydet
                if (model.Image != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", model.Image.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    // Modelin Url özelliğini resmin yolu ile güncelle
                    model.Url = "/images/" + model.Image.FileName;
                }

                var result = await CategoryService.CreateAsync(model);
                if (!result.IsSucceeded)
                {
                    TempData["Error"] = result.Error;
                    return Redirect("/home/error");
                }

                _notyfService.Success("Kategori başarıyla oluşturuldu");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Super Admin, Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await CategoryService.GetByIdAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return Redirect("/home/error");
            }

            CategoryEditViewModel model = new()
            {
                Id = result.Data.Id,
                Name = result.Data.Name,
                Description = result.Data.Description,
                IsActive = result.Data.IsActive,
                Url = result.Data.Url
            };

            return View(model);
        }

        [Authorize(Roles = "Super Admin, Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Eğer resim varsa, dosyayı kaydet
                if (model.Image != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", model.Image.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    // Modelin Url özelliğini resmin yolu ile güncelle
                    model.Url = "/images/" + model.Image.FileName;
                }

                var result = await CategoryService.UpdateAsync(model);
                if (!result.IsSucceeded)
                {
                    ViewData["Error"] = result.Error;
                    return Redirect("/home/error");
                }

                _notyfService.Success("Kategori başarıyla güncellendi");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await CategoryService.DeleteAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return Redirect("/home/error");
            }
            _notyfService.Success("Kategori başarıyla silindi");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Super Admin, Admin")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await CategoryService.GetByIdAsync(id);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return Redirect("/home/error");
            }

            result.Data.IsActive = !result.Data.IsActive;
            var updateResult = await CategoryService.UpdateAsync(new CategoryEditViewModel
            {
                Id = result.Data.Id,
                Name = result.Data.Name,
                Description = result.Data.Description,
                IsActive = result.Data.IsActive,
                Url = result.Data.Url
            });

            if (!updateResult.IsSucceeded)
            {
                TempData["Error"] = updateResult.Error;
                return Redirect("/home/error");
            }

            _notyfService.Success("Kategori durumu güncellendi");
            return Json(result.Data.IsActive);
        }
    }
}