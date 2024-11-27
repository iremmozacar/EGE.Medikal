using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Services;
using System.IO;
using System.Linq;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await CategoryService.GetAllAsync();

            if (!response.IsSucceeded)
            {
                TempData["Error"] = response.Error;
                return Redirect("/home/error");
            }

            var categories = response.Data;



            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create(bool isMainCategory = true)
        {
            var response = await CategoryService.GetAllAsync();

            if (!response.IsSucceeded)
            {
                TempData["Error"] = response.Error;
                return RedirectToAction("Error", "Home");
            }

            var categories = response.Data;

            // CategoryCreateViewModel oluşturuluyor
            var model = new CategoryCreateViewModel
            {
                IsMainCategory = isMainCategory,
                Categories = categories
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
                    .ToList() // Listeye dönüştürülüyor
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Eğer alt kategori ise ParentCategoryId ayarlanır
                model.ParentCategoryId = model.IsMainCategory ? 0 : model.ParentCategoryId;

                var result = await CategoryService.CreateAsync(model);
                if (!result.IsSucceeded)
                {
                    TempData["Error"] = result.Error;
                    return Redirect("/home/error");
                }

                _notyfService.Success("Kategori başarıyla oluşturuldu");
                return RedirectToAction("Index");
            }

            // Model geçersizse, kategori dropdown'ı tekrar dolduruluyor
            var categories = await CategoryService.GetAllAsync();
            model.Categories = categories.Data
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            return View(model);
        }
    }
}