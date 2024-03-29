﻿using System.Data.Entity;
using UrlShortener.Core.Models;
using UrlShortener.Data.Migrations;

namespace UrlShortener.Data
{
     public class UrlShortenerDbContext : DbContext, IUrlShortenerDbContext
     {
        public UrlShortenerDbContext() : base ("Url-Shortener")
        {
            Database.SetInitializer<UrlShortenerDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UrlShortenerDbContext, Configuration>());
        }

        public DbSet<LongUrl> Urls { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
