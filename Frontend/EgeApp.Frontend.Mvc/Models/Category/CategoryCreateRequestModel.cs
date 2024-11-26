using System;

namespace EgeApp.Frontend.Mvc.Models.Category;

public class CategoryCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int ParentCategoryId { get; set; }
    public string Url { get; set; }
    public string ImageBase64 { get; set; }
    public string ImageFileName { get; set; }
}