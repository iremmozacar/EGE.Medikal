using Microsoft.AspNetCore.Mvc;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Shared.Helpers;

namespace EgeApp.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Yeni kategori oluşturma
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryService.CreateAsync(categoryCreateDto);
            return CreateActionResult(response);
        }

        // Alt kategorilerle birlikte kategori oluşturma
        [HttpPost]
        public async Task<IActionResult> CreateWithSubCategories(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryService.CreateWithSubCategoriesAsync(categoryCreateDto);
            return CreateActionResult(response);
        }

        // Kategori güncelleme
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDto);
            return CreateActionResult(response);
        }

        // Kategori silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return CreateActionResult(response);
        }

        // Tüm kategorileri listeleme
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResult(response);
        }

        // Aktif/Pasif kategorileri listeleme
        [HttpGet("{isActive?}")]
        public async Task<IActionResult> GetActives(bool isActive = true)
        {
            var response = await _categoryService.GetActivesAsync(isActive);
            return CreateActionResult(response);
        }

        // Aktif/Pasif kategori sayısını alma
        [HttpGet("{isActive?}")]
        public async Task<IActionResult> GetActivesCount(bool isActive = true)
        {
            var response = await _categoryService.GetActivesCountAsync(isActive);
            return CreateActionResult(response);
        }

        // Toplam kategori sayısını alma
        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var response = await _categoryService.GetCountAsync();
            return CreateActionResult(response);
        }

        // Kategori ID ile alt kategorileri de içeren detay getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryWithSubCategories(int id)
        {
            var response = await _categoryService.GetByIdAsync(id); // Gerekirse ayrı bir metod eklenebilir.
            return CreateActionResult(response);
        }
    }
}