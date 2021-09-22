using LuizaLabs.Infra.Data.Context;
using LuizaLabs.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EntityFrameworkContext _contexto;

        public BaseRepository(EntityFrameworkContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<T> Add(T entity)
        {
            _contexto.Set<T>().Add(entity);
            await _contexto.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            var entry = _contexto.Entry(entity);
            _contexto.Set<T>().Attach(entity);
            if (entry != null)
            {
                entry.State = EntityState.Modified;
            }

            await _contexto.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IQueryable<T>> GetByFilters(System.Linq.Expressions.Expression<Func<T, bool>> predicado, params System.Linq.Expressions.Expression<Func<T, object>>[] inclusoes)
        {
            IQueryable<T> query = await GetAll(inclusoes);

            query = query.Where(predicado);

            return query;
        }

        public async Task<IQueryable<T>> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] inclusoes)
        {
            IQueryable<T> query = _contexto.Set<T>();

            foreach (var item in inclusoes)
            {
                query = query.Include(item);
            }

            return query;
        }

    }
}