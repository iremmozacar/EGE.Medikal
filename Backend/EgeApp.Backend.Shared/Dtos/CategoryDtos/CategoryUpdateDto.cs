﻿namespace EgeApp.Backend.Shared.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }             
        public string Name { get; set; }        
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

    }
}