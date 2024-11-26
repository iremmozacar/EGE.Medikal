using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Data;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Shared.Dtos.ProductDtos;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;
using EgeApp.Backend.Shared.Helpers;
using EgeApp.Backend.Models;

namespace EgeApp.Backend.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            Product product = _mapper.Map<Product>(productCreateDto);
            product.Url = CustomUrlHelper.GetUrl(productCreateDto.Name);
            product.IsActive = product.IsHome ? true : product.IsActive;
            var createdProduct = await _productRepository.CreateAsync(product);
            if (createdProduct == null)
            {
                return ResponseDto<ProductDto>.Fail("Bir hata oluştu", StatusCodes.Status400BadRequest);
            }
            ProductDto createdProductDto = _mapper.Map<ProductDto>(createdProduct);
            createdProductDto.Category = _mapper.Map<CategoryDto>(await _categoryRepository.GetAsync(x => x.Id == createdProductDto.ProductCategoryId));
            return ResponseDto<ProductDto>.Success(createdProductDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<NoContent>> DeleteAsync(int id)
        {
            Product product = await _productRepository.GetAsync(x => x.Id == id);
            if (product == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            await _productRepository.DeleteAsync(product);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetActivesAsync(bool isActive = true)
        {
            List<Product> productList = await _productRepository.GetAllAsync(x => x.IsActive == isActive, x => x.Include(y => y.Category));
            string statusText = isActive ? "aktif" : "pasif";
            if (productList.Count == 0)
            {
                return ResponseDto<List<ProductDto>>.Fail($"Hiç {statusText} ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return ResponseDto<List<ProductDto>>.Success(productDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<int>> GetActivesCountAsync(bool isActive = true)
        {
            int count = await _productRepository.GetCountAsync(x => x.IsActive == isActive);
            string statusText = isActive ? "aktif" : "pasif";
            if (count == 0)
            {
                return ResponseDto<int>.Fail($"{isActive} ürün sayısı 0", StatusCodes.Status404NotFound);
            }
            return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            List<Product> productList = await _productRepository.GetAllAsync(null, x => x.Include(y => y.Category));
            if (productList.Count == 0)
            {
                return ResponseDto<List<ProductDto>>.Fail($"Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return ResponseDto<List<ProductDto>>.Success(productDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllByCategoryIdAsync(int categoryId)
        {
            List<Product> productList = await _productRepository.GetAllAsync(x => x.IsActive == true && x.ProductCategoryId == categoryId, x => x.Include(y => y.Category));
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return ResponseDto<List<ProductDto>>.Fail("Böyle bir kategori yok!", StatusCodes.Status404NotFound);
            }
            if (productList.Count == 0)
            {
                return ResponseDto<List<ProductDto>>.Fail($"{category.Name} kategorisinde hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return ResponseDto<List<ProductDto>>.Success(productDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(int id)
        {
            Product product = await _productRepository.GetAsync(x => x.Id == id, x => x.Include(y => y.Category));
            if (product == null)
            {
                return ResponseDto<ProductDto>.Fail($"{id} id'li ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return ResponseDto<ProductDto>.Success(productDto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<int>> GetCountAsync()
        {
            int count = await _productRepository.GetCountAsync();
            if (count == 0)
            {
                return ResponseDto<int>.Fail($"Ürün sayısı 0", StatusCodes.Status404NotFound);
            }
            return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetHomeAsync(bool isHome = true)
        {
            List<Product> productList = await _productRepository.GetAllAsync(x => x.IsHome == isHome, x => x.Include(y => y.Category));
            string statusText = isHome ? "Ana sayfa ürünü" : "Ana sayfa olmayan ürün";
            if (productList.Count == 0)
            {
                return ResponseDto<List<ProductDto>>.Fail($"Hiç {statusText} bulunamadı!", StatusCodes.Status404NotFound);
            }
            List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
            return ResponseDto<List<ProductDto>>.Success(productDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<int>> GetHomeCountAsync(bool isHome = true)
        {
            int count = await _productRepository.GetCountAsync(x => x.IsHome == isHome);
            string statusText = isHome ? "Ana sayfa ürünü" : "Ana sayfa olmayan ürün";
            if (count == 0)
            {
                return ResponseDto<int>.Fail($"{isHome} sayısı 0", StatusCodes.Status404NotFound);
            }
            return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await _productRepository.GetAsync(x => x.Id == productUpdateDto.Id);
            if (product == null)
            {
                return ResponseDto<ProductDto>.Fail($"{productUpdateDto.Id} id'li ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            var createdDate = product.CreatedDate;
            product = _mapper.Map<Product>(productUpdateDto);
            product.CreatedDate = createdDate;
            product.ModifiedDate = DateTime.Now;
            product.Url = CustomUrlHelper.GetUrl(productUpdateDto.Name);
            product.IsActive = product.IsHome ? true : product.IsActive;
            await _productRepository.UpdateAsync(product);
            var productDto = _mapper.Map<ProductDto>(product);
            productDto.Category = _mapper.Map<CategoryDto>(await _categoryRepository.GetAsync(x => x.Id == productDto.ProductCategoryId));
            return ResponseDto<ProductDto>.Success(productDto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContent>> UpdateIsActiveAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => x.Id == id);
            if (product == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li bir ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            product.IsActive = !product.IsActive;
            product.IsHome = !product.IsActive ? false : product.IsHome;
            await _productRepository.UpdateAsync(product);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContent>> UpdateIsHomeAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => x.Id == id);
            if (product == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li bir ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            product.IsHome = !product.IsHome;
            product.IsActive = product.IsHome ? true : product.IsActive;
            await _productRepository.UpdateAsync(product);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
