using Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mystery.Example.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterNinjectMVC();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterNinjectMVC() => DependencyResolver.SetResolver(new NinjectResolverMVC(CreateKernel())); //https://gist.github.com/odytrice/582108

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new[] { "Mystery.Example.*.dll" }); //https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel -> Dynamic Module Loading need for Onion Architecture;
        
            return kernel;
        }
    }
}
