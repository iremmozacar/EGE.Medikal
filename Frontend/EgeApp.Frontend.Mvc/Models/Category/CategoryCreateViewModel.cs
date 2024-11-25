using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ParentCategoryId { get; set; } // Üst kategori

        public SelectList Categories { get; set; } // Üst kategoriler

        public IFormFile Image { get; set; } // Kategori resmi (dosya yükleme)
        public string Url { get; set; } // Resmin URL'si
    }
}