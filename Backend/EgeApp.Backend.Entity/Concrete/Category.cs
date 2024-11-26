using System;
using System.Collections.Generic;

namespace EgeApp.Backend.Models
{
    public class Category
    {
        public int Id { get; set; } // Kategori ID
        public string Name { get; set; } // Kategori adı
        public string Description { get; set; } // Kategori açıklaması
        public string Url { get; set; } // Kategori URL
        public bool IsActive { get; set; } // Kategorinin aktif olup olmadığı

        // Üst kategori ID'si (nullable)
        public int? ParentCategoryId { get; set; }
        // Üst kategori ilişkisi (nullable)
        public Category ParentCategory { get; set; }

        // Alt kategoriler koleksiyonu, başlatılmış olarak gelir
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        // Ürünler koleksiyonu
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // Ekstra tarih alanları
        public DateTime CreatedDate { get; set; } // Kategori oluşturulma tarihi
        public DateTime ModifiedDate { get; set; } // Kategori son düzenleme tarihi
    }
}