using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using EgeApp.Backend.Data.Abstract;

namespace EgeApp.Backend.Data.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null)
        {
            IQueryable<TEntity> query = _dbSet; //_dbContext.Products
            if (predicate != null)
            {
                query = predicate(query);//_dbContext.Products.Include(x=>x.Category)
            }
            if (options != null)
            {
                query = query.Where(options);//_dbContext.Products.Include(x=>x.Category).Where(x=>x.IsHome==true)
            }
            return await query.ToListAsync();//_dbContext.Products.Include(x=>x.Category).Where(x=>x.IsHome==true).ToListAsync()
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicate != null)
            {
                query = predicate(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }

#pragma warning disable CS8603 // Possible null reference return.
            return await query.AsNoTracking().SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicate != null)
            {
                query = predicate(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }
            return await query.CountAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}



// await _dbSet.ToListAsync();
// await _dbContext.Set<TEntity>().ToListAsync();
// await _dbContext.Products.ToListAsync();
// await _dbContext
//     .Products
//     .Include(x => x.Category)
//     .ToListAsync();
// await _dbContext
//     .Products
//     .Where(x => x.IsHome == true)
//     .Include(x => x.Category)
//     .ToListAsync();
// await _dbContext
//     .Products
//     .Include(x => x.Category)
//     .Where(x => x.Category.Name == "Telefon")
//     .ToListAsync();