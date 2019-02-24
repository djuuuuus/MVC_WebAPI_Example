using Mystery.Example.DAL.Common.Interfaces;
using Mystery.Example.DAL.Repositories.GenericRepository;
using System.Threading.Tasks;

namespace Mystery.Example.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext context) => _context = context;

        public void Dispose() => _context?.Dispose();

        public IGenericRepository<TModel> GetGenericRepository<TModel>() where TModel : class, new() 
            => new GenericRepository<TModel>(_context);

        public int SaveChanges() => _context.SaveChanges();
    }
}
