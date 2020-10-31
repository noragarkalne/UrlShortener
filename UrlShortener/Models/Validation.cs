using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Models
{
    public class Validation
    {
        public static bool IsUrlValid(string a)
        {
            if (a.Trim().ToLower().StartsWith("http://") || a.Trim().ToLower().StartsWith("https://"))
            {
                return true;
            }

            return false;
        }
    }
}