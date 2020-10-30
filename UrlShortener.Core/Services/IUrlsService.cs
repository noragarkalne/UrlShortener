using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services
{
    public interface IUrlsService : IEntityService<LongUrl>
    {
        Task<ServiceResult> AddUrls(LongUrl url);
        Task<LongUrl> GetUrl(int id);
    }
}
