using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;
using UrlShortener.Data;
using UrlShortener.Core.Services;

namespace UrlShortener.Services
{
    public class UrlsService : EntityService<LongUrl>, IUrlsService
    {
        public UrlsService(IUrlShortenerDbContext context) : base(context)
    {
    }

        public async Task<ServiceResult> AddUrls(LongUrl url)
        {
            var urls = await _ctx.Urls.ToListAsync();

            if (urls.Any(f => f.Url.Equals(url.Url)))
            {
                //var x = urls.SingleOrDefault(a => a.Url == url.Url);
                return new ServiceResult(false);
            }

            StringBuilder builder = new StringBuilder(url.Url);
            builder.Replace(url.Url, ShortenUrl());
            string y = builder.ToString();

            return Create(new LongUrl()
            {
                Id = url.Id,
                Url = url.Url,
                Short = new ShortUrl()
                {
                    Id = url.Id,
                    UrlShort = y
                }
            });
        }

        public async Task<LongUrl> GetUrl(int id)
        {
            return await GetById<LongUrl>(id);
        }

        public async Task<LongUrl> Get(string url)
        {
            var urls = await _ctx.Urls.ToListAsync();
            var u = urls.SingleOrDefault(f => f.Url == url);
            return u;

        }


        public static string ShortenUrl()
        {
            var firstPart = "http://www.short.url/";
            StringBuilder builder = new StringBuilder(firstPart);
            builder.Append(GenerateString(5));

            string y = builder.ToString();
            return y;
        }


        static Random rand = new Random();

        public const string Alphabet =
            "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[index: rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }

        public void ClearUrls()
        {
            _ctx.Urls.RemoveRange(_ctx.Urls);
            _ctx.ShortUrls.RemoveRange(_ctx.ShortUrls);
            _ctx.SaveChanges();
        }

    }
}
    

