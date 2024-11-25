namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
