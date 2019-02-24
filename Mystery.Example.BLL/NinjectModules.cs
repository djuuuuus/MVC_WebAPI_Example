using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Services;
using Ninject.Modules;

namespace Mystery.Example.BLL
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerService>();
        }
    }
}
