using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Repository
{
    public abstract class BaseModelRepository<T> : IRepository<T>
        where T : class
    {
        protected ApplicationDbContext Context { get; }

        protected BaseModelRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> includePath)
        {
            return await Context.Set<T>().Include(includePath).ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            return await Task.FromResult(Context.Set<T>().Add(entity));
        }

        public async Task Delete(T entity)
        {
            await Task.FromResult(Context.Set<T>().Remove(entity));
        }
    }
}