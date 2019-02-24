using System;

namespace Mystery.Example.BLL.Services.BaseService
{
    public class BaseService : IDisposable
    {
        //protected IUnitOfWork Uow { get; }

        //protected BaseService(IUnitOfWork uow) => Uow = uow;

        ~BaseService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
