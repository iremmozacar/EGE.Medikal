using EgeApp.Backend.Entity.Abstract;
using System.Collections.Generic;

namespace EgeApp.Backend.Entity.Concrete
{
    public class Category : BaseEntity
    {
        // Alt kategoriler için üst kategori ID'si (FK)
        // Alt kategoriler için üst kategori ID'si (FK)
        public int? ParentCategoryId { get; set; }

        // İlişkili üst kategori (nullable)
        public Category? ParentCategory { get; set; }

        // Alt kategoriler koleksiyonu, başlatılmış olarak gelir
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        // İlişkili ürünler koleksiyonu, başlatılmış olarak gelir
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}