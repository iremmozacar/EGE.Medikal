using System.Collections.Generic;

namespace EgeApp.Frontend.Mvc.Models.Category
{
    public class CategoryIndexViewModel
    {
        public List<CategoryViewModel> MainCategories { get; set; }
        public List<CategoryViewModel> SubCategories { get; set; }
    }
}