namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public List<CategoryCreateDto> SubCategories { get; set; } = new();
    }
}