using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using UrlShortener.Core.Models;
using UrlShortener.Core.Services;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class UrlShortenerController : BasicApiController
    {
        public UrlShortenerController(IUrlsService urlService, IMapper mapper) : base(urlService, mapper)
        {
        }

        // GET: api/UrlShortener
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UrlShortener/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UrlShortener
        public void Post([FromBody]string value)
        {
        }

        [HttpPut, Route("api/url")]
        // PUT: api/UrlShortener/5
        public async Task<IHttpActionResult> Add(LongUrl url)
        {
            if (Validation.IsUrlValid(url.Url) == false)
            {
                return BadRequest();
            }

            var existingUrl = await _urlService.Get(url.Url);

            if (existingUrl != null)
            {
                return Ok(existingUrl.Short);
            }

            var task = await _urlService.AddUrls(url);

            url.Id = task.Entity.Id;

            var url_s = await _urlService.GetUrl(url.Id);
            return Created("", url_s.Short.UrlShort);
        }

        // DELETE: api/UrlShortener/5
        [HttpDelete, Route("api/clear")]
        public IHttpActionResult Clear()
        {
            _urlService.ClearUrls();
            return Ok();
        }


    }
}
