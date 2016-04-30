using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace ColossusBets.Calculator.Api.Castle
{
    internal sealed class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        /// <summary>
        ///     WindsorDependencyScope base constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(
                    "container",
                    "Container of type IWindsorContainer can not be null");
            }

            _container = container;
            _scope = container.BeginScope();
        }

        /// <summary>
        ///     Returns a component instance by the service or null
        /// </summary>
        /// <param name="service">
        ///     The requeste service
        /// </param>
        /// <returns>
        ///     Object or null
        /// </returns>
        public object GetService(Type service)
        {
            return _container.Kernel.HasComponent(service) ? _container.Resolve(service) : null;
        }

        /// <summary>
        ///     Resolve all valid components that match this service the service to matche
        /// </summary>
        /// <param name="service">
        ///     The requeste service
        /// </param>
        /// <returns>
        ///     IEnumerable of object
        /// </returns>
        public IEnumerable<object> GetServices(Type service)
        {
            return _container.ResolveAll(service).Cast<object>().ToArray();
        }

        /// <summary>
        ///     Dispose this object
        /// </summary>
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}