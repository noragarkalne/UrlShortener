using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Models
{
    public class ShortUrlResponse
    {
        public string ShortUrl { get; set; }

        public static ShortUrlResponse NewUrl(string url)
        {
            var result = new ShortUrlResponse()
            {
                ShortUrl = url
            };
            return result;
        }
    }
}