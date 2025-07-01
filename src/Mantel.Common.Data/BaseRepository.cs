using Mantel.Common.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Data
{
    public abstract class BaseRepository<TContext, TModel> : IBaseRepository<TModel> where TModel : class, new() where TContext : DbContext
    {
        public ILogger Logger { get; set; }

        public TContext Context { get; set; }

        protected BaseRepository(TContext context, ILogger logger)
        {
            Context = context;
            Logger = logger;
        }
        protected BaseRepository(TContext context)
        {
            Context = context;
            Logger = NullLogger.Instance;

        }
        public virtual IQueryable<TModel> GetAll()
        {

            IQueryable<TModel> query = Context.Set<TModel>();
            return query;
        }

#if NET6_0_OR_GREATER
        public virtual async Task<TModel?> FindById(object id)
        {
            return await Context.Set<TModel>().FindAsync(id);
        }
#else
        public virtual async Task<TModel> FindById(object id)
        {
            return await Context.Set<TModel>().FindAsync(id);
        }
#endif

        public virtual async Task<IEnumerable<TModel>> FindAll()
        {
            return await Context.Set<TModel>().ToListAsync();
        }

        public virtual async Task<int> Count()
        {
            return await Context.Set<TModel>().CountAsync();
        }

        public virtual async Task<TModel> Add(TModel entity)
        {
            await Context.Set<TModel>().AddAsync(entity);

            return entity;
        }

        public virtual TModel Update(TModel entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;

            return entity;
        }
        public virtual void Delete(TModel entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
