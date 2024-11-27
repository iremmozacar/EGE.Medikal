using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Models;

namespace EgeApp.Backend.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //IGenericRepository'deki tüm metot imzaları Category için burada oluşturuldu, görünmüyor olmasına rağmen.
        //BURADA İSE Category entity'sine ÖZEL METOT İMZALARIMIZ yer alacak.
        
    }
}
