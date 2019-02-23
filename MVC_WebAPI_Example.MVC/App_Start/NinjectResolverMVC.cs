using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_WebAPI_Example.MVC
{
    public class NinjectResolverMVC : IDependencyResolver
    {
        private IKernel Kernel { get; }

        public NinjectResolverMVC(IKernel kernel) => Kernel = kernel;

        public object GetService(Type serviceType) => Kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => Kernel.GetAll(serviceType);
    }
}