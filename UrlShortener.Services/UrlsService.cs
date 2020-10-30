using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;
using UrlShortener.Data;
using UrlShortener.Core.Services;

namespace UrlShortener.Services
{
    public class UrlsService : EntityService<LongUrl>, IUrlsService
    {
        public UrlsService(IUrlShortenerDbContext context) : base(context)
    {
    }

        public async Task<ServiceResult> AddUrls(LongUrl url)
        {
            var urls = await _ctx.Urls.ToListAsync();

            if (urls.Any(f => f.Equals(url)))
            {
                return new ServiceResult(false);
            }

            StringBuilder builder = new StringBuilder(url.Url);
            builder.Replace(url.Url, ShortenUrl());
            string y = builder.ToString();

            return Create(new LongUrl()
            {
                Id = url.Id,
                Url = url.Url,
                Short = new ShortUrl()
                {
                    Id = url.Id,
                    UrlShort = y
                }
            });
        }

        public async Task<LongUrl> GetUrl(int id)
        {
            return await GetById<LongUrl>(id);
        }


        public static string ShortenUrl()
        {
            var firstPart = "http://www.short.url/";
            StringBuilder builder = new StringBuilder(firstPart);
            builder.Append(GenerateString(5));

            string y = builder.ToString();
            return y;
        }


        static Random rand = new Random();

        public const string Alphabet =
            "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[index: rand.Next(Alphabet.Length)];
            }

            return new string(chars);
        }

        public void ClearUrls()
        {
            _ctx.Urls.RemoveRange(_ctx.Urls);
            _ctx.ShortUrls.RemoveRange(_ctx.ShortUrls);
            _ctx.SaveChanges();
        }

        //public async Task<IEnumerable<Flight>> GetFlights()
        //{
        //    return await Query().ToListAsync();
        //}

        //public async Task<Flight> GetFlight(int id)
        //{
        //    return await GetById<Flight>(id);
        //}



        //public void ClearFlights()
        //{
        //    _ctx.Flights.RemoveRange(_ctx.Flights);
        //    _ctx.Airports.RemoveRange(_ctx.Airports);
        //    _ctx.SaveChanges();
        //}

        //public async Task<ServiceResult> DeleteFlight(int id)
        //{
        //    var flights = await _ctx.Flights.ToListAsync();
        //    var flight = flights.SingleOrDefault(f => f.Id.Equals(id));

        //    if (flight == null)
        //    {
        //        return new ServiceResult(id, false);
        //    }

        //    return Delete(flight);
        //}


        //public bool IsFlightValid(Flight flight)
        //{
        //    if (flight == null)
        //    {
        //        return false;
        //    }

        //    if (flight.To != null &&
        //        flight.From != null &&
        //        !string.IsNullOrEmpty(flight.To.Country) &&
        //        !string.IsNullOrEmpty(flight.To.City) &&
        //        !string.IsNullOrEmpty(flight.To.AirportCode) &&
        //        !string.IsNullOrEmpty(flight.From.Country) &&
        //        !string.IsNullOrEmpty(flight.From.City) &&
        //        !string.IsNullOrEmpty(flight.From.AirportCode) &&
        //        !string.IsNullOrEmpty(flight.Carrier) &&
        //        !string.IsNullOrEmpty(flight.DepartureTime) &&
        //        !string.IsNullOrEmpty(flight.ArrivalTime) &&
        //        Convert.ToDateTime(flight.DepartureTime) < Convert.ToDateTime(flight.ArrivalTime))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public bool IsAirportValid(Flight flight)
        //{
        //    if (flight == null)
        //    {
        //        return false;
        //    }

        //    if (!flight.To.AirportCode.ToLower().Trim().Equals(flight.From.AirportCode.ToLower().Trim()) &&
        //        !flight.To.Equals(flight.From))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public async Task<HashSet<Airport>> SearchByIncompletePhrases(string search)
        //{

        //    var airports = _ctx.Airports.Where(x => x.Country.ToString().ToLower().Contains(search.ToLower().Trim()) ||
        //                                     x.City.ToString().ToLower().Contains(search.ToLower().Trim()) ||
        //                                     x.AirportCode.ToString().ToLower().Contains(search.ToLower().Trim()))
        //        .ToList();

        //    var result = airports.ToHashSet();
        //    return result;
        //}

        //public async Task<IEnumerable<Flight>> SearchFlights(FlightSearch req)
        //{
        //    var matchingFlights = await _ctx.Flights.Where(f => f.To.AirportCode.ToLower() == req.To.ToLower() &&
        //                                                        f.From.AirportCode.ToLower() == req.From.ToLower() &&
        //                                                        f.DepartureTime.Contains(req.DepartureDate))
        //        .ToListAsync();
        //    return matchingFlights.DistinctBy(f => new
        //    {
        //        f.DepartureTime,
        //        f.ArrivalTime
        //        ,
        //        f.Carrier,
        //        f.To.City,
        //        f.To.AirportCode,
        //        f.To.Country
        //    }).ToList();

    }
}
    

