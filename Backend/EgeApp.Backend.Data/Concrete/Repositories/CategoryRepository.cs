using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        // DbContext'i constructor üzerinden enjekte ediyoruz
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // SaveChangesAsync metodunu burada kullanabiliriz
        public async Task SaveChangesAsync()
        {
            // DbContext nesnesini burada kullanıyoruz
            await _dbContext.SaveChangesAsync();
        }
    }
}