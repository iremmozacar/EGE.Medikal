namespace EgeApp.Backend.Shared.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public int CategoryId { get; set; }
    }
}
