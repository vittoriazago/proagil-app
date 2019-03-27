using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
    public interface IProAgilRepositorio<T> where T : class
    {
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<bool> SaveChangesAsync();
         
         Task<IEnumerable<T>> GetListAsync(params Expression<Func<T, object>>[] includes);
         Task<IEnumerable<T>> GetListFilterAsync(Expression<Func<T, bool>> filter,
                    params Expression<Func<T, object>>[] includes);

    }
}