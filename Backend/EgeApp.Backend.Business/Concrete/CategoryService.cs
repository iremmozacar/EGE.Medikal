using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;
using EgeApp.Backend.Shared.Helpers;
using EgeApp.Backend.Shared.ResponseDtos;
using EgeApp.Backend.Models;
using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Data;

namespace EgeApp.Backend.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            // URL otomatik olarak oluşturuluyor
            string url = CustomUrlHelper.GetUrl(categoryCreateDto.Name);
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.Url = url; // URL atanıyor

            var createdCategory = await _categoryRepository.CreateAsync(category);
            if (createdCategory == null)
            {
                return ResponseDto<CategoryDto>.Fail("Kategori oluşturulamadı.", StatusCodes.Status400BadRequest);
            }

            CategoryDto categoryDto = _mapper.Map<CategoryDto>(createdCategory);
            return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<CategoryDto>> CreateWithSubCategoriesAsync(CategoryCreateDto categoryCreateDto)
        {
            // Parent kategori için URL oluşturuluyor
            string parentUrl = CustomUrlHelper.GetUrl(categoryCreateDto.Name);
            Category parentCategory = _mapper.Map<Category>(categoryCreateDto);
            parentCategory.Url = parentUrl;

            var createdParentCategory = await _categoryRepository.CreateAsync(parentCategory);
            if (createdParentCategory == null)
            {
                return ResponseDto<CategoryDto>.Fail("Ana kategori oluşturulamadı.", StatusCodes.Status400BadRequest);
            }

            // Alt kategoriler için işleme devam ediyoruz
            if (categoryCreateDto.SubCategories != null && categoryCreateDto.SubCategories.Any())
            {
                foreach (var subCategoryDto in categoryCreateDto.SubCategories)
                {
                    string subUrl = CustomUrlHelper.GetUrl(subCategoryDto.Name);
                    Category subCategory = _mapper.Map<Category>(subCategoryDto);
                    subCategory.Url = subUrl;
                    subCategory.ParentCategoryId = createdParentCategory.Id;

                    var createdSubCategory = await _categoryRepository.CreateAsync(subCategory);
                    if (createdSubCategory == null)
                    {
                        return ResponseDto<CategoryDto>.Fail("Alt kategori oluşturulamadı.", StatusCodes.Status400BadRequest);
                    }
                }
            }

            CategoryDto result = _mapper.Map<CategoryDto>(createdParentCategory);
            return ResponseDto<CategoryDto>.Success(result, StatusCodes.Status201Created);
        }
        public async Task<ResponseDto<NoContent>> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id);
            if (category == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            await _categoryRepository.DeleteAsync(category);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetActivesAsync(bool isActive = true)
        {
            var categoryList = await _categoryRepository.GetAllAsync(x => x.IsActive == isActive);
            string statusText = isActive ? "aktif" : "pasif";
            if (categoryList.Count == 0)
            {
                return ResponseDto<List<CategoryDto>>.Fail($"Hiç {statusText} kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categoryList);
            return ResponseDto<List<CategoryDto>>.Success(categoryDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<int>> GetActivesCountAsync(bool isActive = true)
        {
            int count = await _categoryRepository.GetCountAsync(x => x.IsActive == isActive);
            string statusText = isActive ? "aktif" : "pasif";
            if (count == 0)
            {
                return ResponseDto<int>.Fail($"Hiç {statusText} kategori yok!", StatusCodes.Status404NotFound);
            }
            return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categoryList = await _categoryRepository.GetAllAsync();

            if (categoryList.Count == 0)
            {
                return ResponseDto<List<CategoryDto>>.Fail($"Hiç kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categoryList);
            return ResponseDto<List<CategoryDto>>.Success(categoryDtoList, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id);

            if (category == null)
            {
                return ResponseDto<CategoryDto>.Fail($"{id} id'li kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<int>> GetCountAsync()
        {
            int count = await _categoryRepository.GetCountAsync();
            if (count == 0)
            {
                return ResponseDto<int>.Fail("Hiç kategori yok!", StatusCodes.Status404NotFound);
            }
            return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryUpdateDto.Id);
            if (category == null)
            {
                return ResponseDto<CategoryDto>.Fail("Böyle bir kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedDate = DateTime.Now;
            category.Url = CustomUrlHelper.GetUrl(categoryUpdateDto.Name);
            await _categoryRepository.UpdateAsync(category);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status200OK);
        }
    }
}