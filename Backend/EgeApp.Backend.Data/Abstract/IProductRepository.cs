using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Entity.Concrete;

namespace EgeApp.Backend.Data;

public interface IProductRepository : IGenericRepository<Product>
{
    //IGenericRepository'deki tüm metot imzaları Product için burada oluşturuldu, görünmüyor olmasına rağmen.
    //BURADA İSE Product entity'sine ÖZEL METOT İMZALARIMIZ yer alacak.
    Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
}
