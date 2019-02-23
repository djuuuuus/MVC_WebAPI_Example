using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_WebAPI_Example.MVC
{
    //https://gist.github.com/odytrice/5821087
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel Kernel { get; }

        public NinjectResolver()
        {
            Kernel = new StandardKernel();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("MVC_WebAPI_Example")).ToArray();

            Kernel.Load(assemblies); //https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel -> Dynamic Module Loading need for Onion Architecture;
        }

        public object GetService(Type serviceType) => Kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => Kernel.GetAll(serviceType);
    }
}