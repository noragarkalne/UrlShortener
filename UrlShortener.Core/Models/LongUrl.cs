namespace UrlShortener.Core.Models
{
    public class LongUrl : Entity
    {
        public string Url { get; set; }

        public virtual ShortUrl Short { get; set; }
    }
}
