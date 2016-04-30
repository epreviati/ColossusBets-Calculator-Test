using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace ColossusBets.Calculator.Api.Castle
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        /// <summary>
        ///     WindsorDependencyResolver base constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(
                    "container",
                    "Container of type IWindsorContainer can not be null");
            }

            _container = container;
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
        ///     Returns a new instance of an IDependencyScope
        /// </summary>
        /// <returns>
        ///     IDependencyScope
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        /// <summary>
        ///     Dispose this object
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}