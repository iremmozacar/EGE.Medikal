using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
