using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryCreateViewModel
    {
        public bool IsMainCategory { get; set; }
        public List<SelectListItem> Categories { get; set; }  // Bu, alt kategori seçiminde kullanılıyor.
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Url { get; set; }
        public IFormFile Image { get; set; }
    }
}
