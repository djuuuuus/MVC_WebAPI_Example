using System.Web.Http;
using Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_WebAPI_Example.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //1 
            //GlobalConfiguration.Configure(WebApiConfig.Register); //https://stackoverflow.com/questions/11990036/how-to-add-web-api-to-an-existing-asp-net-mvc-4-web-application-project
            //RegisterNinjectShared();                              //https://www.radenkozec.com/simple-way-share-container-mvc-web-api/

            //2 
            RegisterNinjectMVC();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new[] { "MVC_WebAPI_Example.*.dll" }); //https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel -> Dynamic Module Loading need for Onion Architecture;

            return kernel;
        }

        private void RegisterNinjectMVC() => DependencyResolver.SetResolver(new NinjectResolverMVC(CreateKernel())); //https://gist.github.com/odytrice/582108

        private void RegisterNinjectShared()
        {
            var ninjectResolverShared = new NinjectResolverShared(CreateKernel());

            DependencyResolver.SetResolver(ninjectResolverShared); // MVC
            GlobalConfiguration.Configuration.DependencyResolver = ninjectResolverShared; // Web API
        }
    }
}
