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

        public async Task<IEnumerable<T>> GetListAsync(
            params Expression<Func<T, object>>[] includes)
        {
            var list = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                list = includes.Aggregate(list,
                        (current, include) => current.Include(include));
            }
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListFilterAsync(
            Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes)
        {
            var list = _context.Set<T>().Where(filter);
            if (includes != null)
            {
                list = includes.Aggregate(list,
                        (current, include) => current.Include(include));
            }
            return await list.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}