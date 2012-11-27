using System;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace Cedar.WebPortal.Configuration
{
    using System.Collections.Generic;

    class LocalNinjectDependencyResolver : IDependencyResolver
    {
        public LocalNinjectDependencyResolver(IKernel k)
        {
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}