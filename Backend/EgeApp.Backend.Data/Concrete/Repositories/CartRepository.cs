using System;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
