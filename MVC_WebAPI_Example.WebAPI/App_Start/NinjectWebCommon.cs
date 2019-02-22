using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MVC_WebAPI_Example.BLL.Common.Interfaces;
using MVC_WebAPI_Example.BLL.Services;
using MVC_WebAPI_Example.WebAPI.App_Start;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace MVC_WebAPI_Example.WebAPI.App_Start
{
    //https://stackoverflow.com/questions/20595472/mvc5-web-api-2-and-ninject
    public static class NinjectWebCommon
    {
        private static IKernel kernel;

        private static void RegisterServices()
        {
            kernel.Bind<ITestService>().To<TestService>();
        }

        #region Initialize 

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices();

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public static TService GetService<TService>(Type serviceType = null) where TService : class
        {
            if (serviceType == null)
            {
                var service = kernel.Get<TService>();
                return service;
            }

            // TODO add exception
            return null;
        }

        #endregion 
    }
}