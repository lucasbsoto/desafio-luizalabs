using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Repository
{
    public interface IRepositorioBase<T> where T : class 
    {
        Task<T> Adicionar(T entity);
        Task<IQueryable<T>> PesquisarTodos(params Expression<Func<T, object>>[] inclusoes);
        Task<T> Alterar(T entity);
        Task<IQueryable<T>> PesquisarPor(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] inclusoes);
    }
}
