using Mystery.Example.DAL.Common.Interfaces;
using Mystery.Example.DAL.Repositories;

namespace Mystery.Example.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext context;

        public UnitOfWork(ShopDbContext context) => this.context = context;

        public void Dispose() => context?.Dispose();

        public IGenericRepository<TModel> GetGenericRepository<TModel>() where TModel : class, new() 
            => new GenericRepository<TModel>(context);

        public int SaveChanges() => context.SaveChanges();
    }
}
