namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }               // Kategori ID
        public string Name { get; set; }         // Kategori adı
        public bool IsActive { get; set; }       // Aktiflik durumu
        public string Url { get; set; }          // Kategori URL (otomatik oluşturuluyor)
        public string Description { get; set; } // Kategori açıklaması
        public int? ParentCategoryId { get; set; } // Üst kategori ID
        public string ParentCategoryName { get; set; } // Üst kategori adı
        public List<CategoryDto> SubCategories { get; set; } = new(); // Alt kategoriler
    }

}