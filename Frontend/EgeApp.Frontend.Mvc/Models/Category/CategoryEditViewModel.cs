using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } // Var olan görselin URL'si
        public IFormFile Image { get; set; } // Yeni görsel için dosya yükleme
        public int ParentCategoryId { get; set; } // Üst kategori seçimi
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>(); // Üst kategoriler için liste
    }
}