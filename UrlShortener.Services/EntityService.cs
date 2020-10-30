using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;
using UrlShortener.Core.Services;
using UrlShortener.Data;

namespace UrlShortener.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IUrlShortenerDbContext context) : base(context)
        {
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            return QueryById<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await GetById<T>(id);
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }

        public bool Exists(int id)
        {
            return Exists<T>(id);
        }
    }
}
// this class helps that when new object like city is created all service things are ready;

