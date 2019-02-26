using Mastery.Example.BLL.Common.Interfaces;
using Mastery.Example.BLL.Services;
using Ninject.Modules;

namespace Mastery.Example.BLL
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerService>();
        }
    }
}
