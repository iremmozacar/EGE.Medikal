using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace EgeApp.Backend.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        //x=>x.Id==3
        //LINQ-Language Integrated Query
        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>>? options = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null
        );
        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? options = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null
        );
        Task<int> GetCountAsync(
            Expression<Func<TEntity, bool>>? options = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? predicate = null

        );
        // Get Home (Entities with IsHome = true)
        Task<List<TEntity>> GetHomeAsync();

        // Pagination
        Task<(List<TEntity>, int)> GetPagedAsync(
            int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        // Sorting
        Task<List<TEntity>> GetSortedAsync<TKey>(
            Expression<Func<TEntity, TKey>> orderBy,
            bool isDescending = false,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        // Add Range
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        // Update Range
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}

