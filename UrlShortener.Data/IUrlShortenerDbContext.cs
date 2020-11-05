using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Data
{
    public interface IUrlShortenerDbContext
    {
        DbSet<T> Set<T>() where T : class; 
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

        Task<int> SaveChangesAsync(); 
       

        DbSet<LongUrl> Urls { get; set; }
        DbSet<ShortUrl> ShortUrls { get; set; }
    }
}