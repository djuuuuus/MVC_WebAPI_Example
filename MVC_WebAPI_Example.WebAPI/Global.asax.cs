using System.Web.Http;
using Ninject;

namespace MVC_WebAPI_Example.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterNinjectWebAPI();
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new[] { "MVC_WebAPI_Example.*.dll" }); //https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel -> Dynamic Module Loading need for Onion Architecture;

            return kernel;
        }

        private void RegisterNinjectWebAPI() => GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolverWebAPI(CreateKernel()); //https://gist.github.com/odytrice/5842010
    }
}
