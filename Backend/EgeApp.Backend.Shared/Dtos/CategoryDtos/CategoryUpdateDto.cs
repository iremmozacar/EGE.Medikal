namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }               // Kategori ID
        public string Name { get; set; }         // Kategori adı
        public bool IsActive { get; set; }       // Aktiflik durumu
        public string Description { get; set; } // Kategori açıklaması
    }
}