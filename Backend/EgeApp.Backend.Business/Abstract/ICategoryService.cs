using EgeApp.Backend.Shared.Dtos.CategoryDtos;
using EgeApp.Backend.Shared.Dtos.ResponseDtos;
using EgeApp.Backend.Shared.ResponseDtos;

namespace EgeApp.Backend.Business.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<ResponseDto<CategoryDto>> CreateWithSubCategoriesAsync(CategoryCreateDto categoryCreateDto);
        Task<ResponseDto<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<ResponseDto<NoContent>> DeleteAsync(int id);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(int id);
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync();
        Task<ResponseDto<List<CategoryDto>>> GetActivesAsync(bool isActive = true);
        Task<ResponseDto<int>> GetCountAsync();
        Task<ResponseDto<int>> GetActivesCountAsync(bool isActive = true);
    }
}
