using System;

namespace Mystery.Example.DAL.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TModel> GetGenericRepository<TModel>()
            where TModel : class, new();

        int SaveChanges();
    }
}
