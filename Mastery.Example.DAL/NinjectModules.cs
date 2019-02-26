using Mystery.Example.DAL.Common.Interfaces;
using Ninject.Modules;

namespace Mystery.Example.DAL
{
    public class NinjectModules : NinjectModule
    {
        public override void Load()
        {
            Bind<ShopDbContext>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
