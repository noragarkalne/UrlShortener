using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services
{
    public interface IUrlsService : IEntityService<LongUrl>
    {
        Task<ServiceResult> AddUrls(LongUrl url);
        Task<LongUrl> GetUrl(int id);
        Task<LongUrl> Get(string url);
        Task<LongUrl> GetShortUrl(string shortUrl);
        string GenerateString(int size);
        string ShortenUrl();
        void ClearUrls();
    }
}
