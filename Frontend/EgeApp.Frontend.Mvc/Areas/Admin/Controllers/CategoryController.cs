using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Services;
using System.IO;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await CategoryService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                TempData["Error"] = response.Error;
                return RedirectToAction("Error", "Home");
            }

            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Varsayılan model oluşturuluyor
            return View(new CategoryCreateViewModel { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Lütfen geçerli kategori bilgileri giriniz.");
                return View(model);
            }

            if (model.Image != null)
            {
                try
                {
                    // Görselin yüklenmesi
                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(model.Image.FileName)}";
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/categories", fileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    model.ImageUrl = $"/uploads/categories/{fileName}";
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Görsel yüklenirken hata oluştu: {ex.Message}");
                    return View(model);
                }
            }

            var result = await CategoryService.CreateAsync(model);
            if (!result.IsSucceeded)
            {
                _notyfService.Error(result.Error ?? "Kategori oluşturulamadı.");
                return View(model);
            }

            _notyfService.Success("Kategori başarıyla oluşturuldu.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await CategoryService.GetByIdAsync(id);

            if (!response.IsSucceeded)
            {
                _notyfService.Error(response.Error ?? "Kategori bulunamadı.");
                return RedirectToAction("Index");
            }

            var model = new CategoryEditViewModel
            {
                Id = response.Data.Id,
                Name = response.Data.Name,
                Description = response.Data.Description,
                Url = response.Data.Url,
                IsActive = response.Data.IsActive,
                ImageUrl = response.Data.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Lütfen geçerli kategori bilgileri giriniz.");
                return View(model);
            }

            if (model.Image != null)
            {
                try
                {
                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(model.Image.FileName)}";
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/categories", fileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    model.ImageUrl = $"/uploads/categories/{fileName}";
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Görsel yüklenirken hata oluştu: {ex.Message}");
                    return View(model);
                }
            }

            var result = await CategoryService.UpdateAsync(model);
            if (!result.IsSucceeded)
            {
                _notyfService.Error(result.Error ?? "Kategori güncellenemedi.");
                return View(model);
            }

            _notyfService.Success("Kategori başarıyla güncellendi.");
            return RedirectToAction("Index");
        }
    }
}
