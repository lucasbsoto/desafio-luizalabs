using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<T> Add(T entity);
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] inclusoes);
        Task<T> Update(T entity);
        Task<IQueryable<T>> GetByFilters(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] inclusoes);
    }
}
