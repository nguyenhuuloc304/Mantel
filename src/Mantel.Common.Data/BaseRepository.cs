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

        public async Task<IReadOnlyList<TModel>> GetAllAsync()
        {
            return await Context.Set<TModel>()
                .ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            return await Context.Set<TModel>().FindAsync(id);
        }

        public async Task<TModel> AddAsync(TModel entity)
        {
            await Context.Set<TModel>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Guid id, TModel entity)
        {
            var oldItem = await GetByIdAsync(id);
            Context.Entry(oldItem).CurrentValues.SetValues(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TModel entity)
        {
            Context.Set<TModel>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
