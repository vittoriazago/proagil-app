using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository.Data;

namespace ProAgil.Repository
{
    public class ProAgilRepository<T> : IProAgilRepositorio<T> 
        where T : class
    {
        public readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            this._context = context;

        }
        public void Add(T entity) 
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetListFilterAsync(Expression<Func<T, bool>> filter)
        {
            var list = _context.Set<T>().Where(filter);

            return list;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}