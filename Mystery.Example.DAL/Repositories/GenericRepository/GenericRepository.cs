using Mystery.Example.DAL.Common.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Mystery.Example.DAL.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private ShopDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        ~GenericRepository() => ReleaseUnmanagedResources();

        private void ReleaseUnmanagedResources()
        {
            _context?.Dispose();
            _context = null;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        #region CRUD

        public IQueryable<TEntity> GetQuery() => _dbSet;

        public IQueryable<TEntity> GetQueryAsNoTracking() => _dbSet.AsNoTracking().AsQueryable();

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity) => _dbSet.Remove(entity);
 
        #endregion
    }
}
