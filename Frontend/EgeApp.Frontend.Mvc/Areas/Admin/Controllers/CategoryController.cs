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
            var model = new CategoryCreateViewModel
            {
                IsActive = true // Default value for new categories
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Please check the category information and try again.");
                return View(model);
            }

            // Map the view model to the service model
            var categoryToCreate = new CategoryCreateViewModel
            {
                Name = model.Name,
                Description = model.Description,
                Url = model.Url,
                IsActive = model.IsActive
            };

            // Handle image upload if an image is provided
            if (model.Image != null && model.Image.Length > 0)
            {
                try
                {
                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(model.Image.FileName)}";
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/categories", fileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    categoryToCreate.ImageUrl = $"/uploads/categories/{fileName}";
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Error while uploading image: {ex.Message}");
                    return View(model);
                }
            }

            var result = await CategoryService.CreateAsync(categoryToCreate);
            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return RedirectToAction("Error", "Home");
            }

            _notyfService.Success("Category successfully created.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await CategoryService.GetByIdAsync(id);

            if (!response.IsSucceeded)
            {
                TempData["Error"] = response.Error;
                return RedirectToAction("Error", "Home");
            }

            var category = response.Data;

            var model = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Url = category.Url,
                IsActive = category.IsActive,
                ImageUrl = category.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Please check the category information and try again.");
                return View(model);
            }

            // Map the view model to the service model
            var categoryToUpdate = new CategoryEditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Url = model.Url,
                IsActive = model.IsActive,
                ImageUrl = model.ImageUrl
            };

            // Handle new image upload if provided
            if (model.Image != null && model.Image.Length > 0)
            {
                try
                {
                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(model.Image.FileName)}";
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/categories", fileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    categoryToUpdate.ImageUrl = $"/uploads/categories/{fileName}";
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Error while uploading image: {ex.Message}");
                    return View(model);
                }
            }

            var result = await CategoryService.UpdateAsync(categoryToUpdate);

            if (!result.IsSucceeded)
            {
                TempData["Error"] = result.Error;
                return RedirectToAction("Error", "Home");
            }

            _notyfService.Success("Category successfully updated.");
            return RedirectToAction("Index");
        }
    }
}
