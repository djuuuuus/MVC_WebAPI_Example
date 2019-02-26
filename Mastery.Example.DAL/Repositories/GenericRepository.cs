using System;
using System.Data.Entity;
using System.Linq;
using Mystery.Example.DAL.Common.Interfaces;

namespace Mystery.Example.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private ShopDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(ShopDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = this.context.Set<TEntity>();
        }

        ~GenericRepository() => ReleaseUnmanagedResources();

        private void ReleaseUnmanagedResources()
        {
            context?.Dispose();
            context = null;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        #region CRUD

        public IQueryable<TEntity> GetQuery() => dbSet;

        public IQueryable<TEntity> GetQueryAsNoTracking() => dbSet.AsNoTracking().AsQueryable();

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity) => dbSet.Remove(entity);
 
        #endregion
    }
}
