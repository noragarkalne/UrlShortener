using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using UrlShortener.Core.Models;
using UrlShortener.Core.Services;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [EnableCors ("*", "*", "*")]
    public class UrlShortenerController : BasicApiController
    {
        public UrlShortenerController(IUrlsService urlService, IMapper mapper) : base(urlService, mapper)
        {
        }

        [HttpPut, Route("api/put/url")]
        public async Task<IHttpActionResult> Add(LongUrl url)
        {
            if (Validation.IsUrlValid(url.Url) == false)
            {
                return BadRequest();
            }

            var existingUrl = await _urlService.Get(url.Url);

            if (existingUrl != null)
            {
                return Ok(existingUrl.Short.UrlShort);
            }

            var existingShortUrl = await _urlService.GetShortUrl(url.Url);

            if (existingShortUrl != null)
            {
                return Ok(existingShortUrl.Url);
            }

            var task = await _urlService.AddUrls(url);

            url.Id = task.Entity.Id;

            var url_s = await _urlService.GetUrl(url.Id);
            return Created("", url_s.Short.UrlShort);
        }

    
        [HttpDelete, Route("api/clear")]
        public IHttpActionResult Clear()
        {
            _urlService.ClearUrls();
            return Ok();
        }
    }
}
