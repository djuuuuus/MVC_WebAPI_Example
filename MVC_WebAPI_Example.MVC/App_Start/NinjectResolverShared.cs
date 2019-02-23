using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

namespace MVC_WebAPI_Example.MVC
{
    public class NinjectResolverShared :
        NinjectDependencyScope,
        System.Web.Http.Dependencies.IDependencyResolver, // WebAPI. Depend from Microsoft.AspNet.WebApi package.
        System.Web.Mvc.IDependencyResolver // MVC
    {
        private IKernel Kernel { get; }

        public NinjectResolverShared(IKernel Kernel) : base(Kernel)
        {
            this.Kernel = Kernel;
        }

        public IDependencyScope BeginScope() => new NinjectDependencyScope(Kernel.BeginBlock());
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        public IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = this.resolver as IDisposable;

            disposable?.Dispose();

            this.resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.GetAll(serviceType);
        }
    }
}