using Microsoft.AspNetCore.Http;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
        public IFormFile Image { get; set; } // For uploading the image
        public string ImageUrl { get; set; }
    }
}
