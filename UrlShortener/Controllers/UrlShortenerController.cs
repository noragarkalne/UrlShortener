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

        // PUT: api/UrlShortener/5
        public async Task<IHttpActionResult> Add(LongUrl url)
        {
            var task = await _urlService.AddUrls(url);

            if (task.Succeeded == false)
            {
                return Conflict();
            }

            url.Id = task.Entity.Id;
            return Created("", _mapper.Map<ShortUrlResponse>(url));
        }

        // DELETE: api/UrlShortener/5
            public void Delete(int id)
        {
        }

        
    }
}
