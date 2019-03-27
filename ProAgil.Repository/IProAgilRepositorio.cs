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
         
         IEnumerable<T> GetList();
         Task<IEnumerable<T>> GetListFilterAsync(Expression<Func<T, bool>> filter);

    }
}