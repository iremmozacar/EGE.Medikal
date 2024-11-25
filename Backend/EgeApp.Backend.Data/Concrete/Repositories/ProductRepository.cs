using EgeApp.Backend.Entity.Concrete;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
