using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Data
{
     public class UrlShortenerDbContext : DbContext, IUrlShortenerDbContext
    {
        public UrlShortenerDbContext() : base ("Url-Shortener")
        {
            Database.SetInitializer<UrlShortenerDbContext>(null);
        }

        public DbSet<LongUrl> Urls { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
