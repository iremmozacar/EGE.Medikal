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

namespace EgeApp.Backend.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        //Dependency Injection / DI
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            string url = CustomUrlHelper.GetUrl(categoryCreateDto.Name);
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.Url = url;
            var createdCategory = await _categoryRepository.CreateAsync(category);
            if (createdCategory == null)
            {
                return ResponseDto<CategoryDto>.Fail("Bir hata oluştu", StatusCodes.Status400BadRequest);
            }
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(createdCategory);

            return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status201Created);
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