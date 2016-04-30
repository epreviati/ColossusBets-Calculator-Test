using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ColossusBets.Calculator.Api.Castle
{
    /// <summary>
    ///     Setup webapi
    /// </summary>
    public class WebApiInstaller : IWindsorInstaller
    {
        /// <summary>
        ///     Registers components into Castle
        /// </summary>
        /// <param name="container">Container</param>
        /// <param name="store">Store</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
        }
    }
}