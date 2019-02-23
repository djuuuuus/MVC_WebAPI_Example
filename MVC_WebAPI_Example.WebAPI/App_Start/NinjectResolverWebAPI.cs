using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace MVC_WebAPI_Example.WebAPI
{
    public class NinjectResolverWebAPI : IDependencyResolver, IDependencyScope
    {
        private IKernel Kernel { get; }

        public NinjectResolverWebAPI(IKernel kernel) => Kernel = kernel;

        public object GetService(Type serviceType) => Kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => Kernel.GetAll(serviceType);

        public void Dispose()
        {
            //Do Nothing
        }

        public IDependencyScope BeginScope() => this;
    }
}