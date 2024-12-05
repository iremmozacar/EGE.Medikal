using System;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    


        public async Task<Cart> GetCartAsync(string userId)
        {
            return await _dbContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId); // SingleOrDefault yerine FirstOrDefault kullanıyoruz
        }
    }
}
