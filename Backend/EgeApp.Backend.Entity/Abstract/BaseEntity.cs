namespace EgeApp.Backend.Entity.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Tüm entity'ler için birincil anahtar
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime ModifiedDate { get; set; } = DateTime.Now; // Güncellenme tarihi
        public bool IsActive { get; set; } = true; // Aktiflik durumu
        public string Name { get; set; } // Ürün veya kategori adı
        public string Url { get; set; } // SEO dostu URL
        public string Description { get; set; } // Açıklama alanı, hem ürün hem kategori için faydalı
    }
}