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
        public bool IsActive { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
