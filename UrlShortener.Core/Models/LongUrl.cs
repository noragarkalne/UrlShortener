using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Models
{
    public class LongUrl : Entity
    {
        public string Url { get; set; }

        public virtual ShortUrl Short { get; set; }
    }
}
