using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShortener.Core.Services;
using UrlShortener.Services;

namespace UrlShortenerTest
{
    [TestClass]
    public class UrlShortenerTest
    {
        private IUrlsService _service;

        public UrlShortenerTest()
        {
            _service = new UrlsService();
        }

        [TestMethod]
        public void GenerateString()
        {
            var randomString = _service.GenerateString(5);
            Assert.IsNotNull(randomString);
        }

        [TestMethod]
        public void ShortenUrl()
        {
            var shortUrl = _service.ShortenUrl();
            Assert.IsNotNull(shortUrl);
        }
    }
}
