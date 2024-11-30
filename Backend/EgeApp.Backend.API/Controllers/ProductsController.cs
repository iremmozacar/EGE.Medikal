using Microsoft.AspNetCore.Mvc;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Shared.Dtos.ProductDtos;
using EgeApp.Backend.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Data;

namespace EgeApp.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : CustomControllerBase
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _dbContext;

        public ProductsController(IProductService productService, AppDbContext dbContext)
        {
            _productService = productService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var response = await _productService.CreateAsync(productCreateDto);
            return CreateActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response = await _productService.UpdateAsync(productUpdateDto);
            return CreateActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return CreateActionResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return CreateActionResult(response);
        }

        [HttpGet("GetDiscountedProducts")]
        public async Task<IActionResult> GetDiscountedProducts()
        {
            var discountedProducts = await _dbContext.Products
                .Where(p => p.IsDiscounted && p.IsActive)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountedPrice = p.DiscountedPrice,
                    ImageUrl = p.ImageUrl,
                    IsDiscounted = p.IsDiscounted,
                    IsActive = p.IsActive,
                    ProductCategoryId = p.ProductCategoryId,
                    Category = new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    }
                })
                .ToListAsync();

            return Ok(discountedProducts);
        }
        [HttpGet("GetBestSellers/{topCount?}")]
        public async Task<IActionResult> GetBestSellers(int topCount = 10)
        {
            var bestSellers = await _dbContext.Products
                .Where(p => p.IsActive) // Sadece aktif ürünler
                .OrderByDescending(p => p.SalesCount) // Satış miktarına göre sıralama
                .Take(topCount) // En çok satanlardan ilk `topCount` kadarını al
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountedPrice = p.DiscountedPrice,
                    ImageUrl = p.ImageUrl,
                    SalesCount = p.SalesCount,
                    IsActive = p.IsActive,
                    ProductCategoryId = p.ProductCategoryId,
                    Category = new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    }
                })
                .ToListAsync();

            return Ok(bestSellers);
        }

        [HttpGet("{isActive?}")]
        public async Task<IActionResult> GetActives(bool isActive = true)
        {
            var response = await _productService.GetActivesAsync(isActive);
            return CreateActionResult(response);
        }

        [HttpGet("{isHome?}")]
        public async Task<IActionResult> GetHomes(bool isHome = true)
        {
            var response = await _productService.GetHomeAsync(isHome);
            return CreateActionResult(response);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _productService.GetAllByCategoryIdAsync(categoryId);
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return CreateActionResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var response = await _productService.GetCountAsync();
            return CreateActionResult(response);
        }

        [HttpGet("{isActive?}")]
        public async Task<IActionResult> GetActivesCount(bool isActive = true)
        {
            var response = await _productService.GetActivesCountAsync(isActive);
            return CreateActionResult(response);
        }

        [HttpGet("{isHome?}")]
        public async Task<IActionResult> GetHomesCount(bool isHome = true)
        {
            var response = await _productService.GetHomeCountAsync(isHome);
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var response = await _productService.UpdateIsHomeAsync(id);
            return CreateActionResult(response);
        }

    }
}