using System.Web.Http;
using AutoMapper;
using UrlShortener.Core.Services;

namespace UrlShortener.Controllers
{
    public class BasicApiController : ApiController
    {
        protected readonly IUrlsService _urlService;
        protected readonly IMapper _mapper;

        public BasicApiController(IUrlsService urlService, IMapper mapper)
        {
            _urlService = urlService;
            _mapper = mapper;
        }
    }
}