using AutoMapper;
using UrlShortener.Core.Models;
using UrlShortener.Models;

namespace UrlShortener
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LongUrl, ShortUrlResponse>()
                    .ForMember(x => x.ShortUrl, o =>o.Ignore());
                
                cfg.CreateMap<ShortUrlResponse, LongUrl>()
                    .ForPath(x => x.Short.UrlShort
                    , o => o.MapFrom(
                        s => new ShortUrlResponse()
                    ))
                    .ForPath(x => x.Short.Id
                        , o => o.Ignore())
                    .ForMember(b => b.Id, o => o.Ignore())
                    .ForMember(c => c.Url, o =>o.Ignore());
                
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}