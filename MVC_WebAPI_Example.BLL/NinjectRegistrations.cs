using MVC_WebAPI_Example.BLL.Common.Interfaces;
using MVC_WebAPI_Example.BLL.Services;
using Ninject.Modules;

namespace MVC_WebAPI_Example.BLL
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestService>().To<TestService>();
        }
    }
}