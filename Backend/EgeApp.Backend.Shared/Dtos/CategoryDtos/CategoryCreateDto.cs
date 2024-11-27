namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }
    }
}