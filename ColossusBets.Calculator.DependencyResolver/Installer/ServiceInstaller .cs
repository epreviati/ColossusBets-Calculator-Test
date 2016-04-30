using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ColossusBets.Calculator.Service;
using ColossusBets.Calculator.Service.Implementation;

namespace ColossusBets.Calculator.DependencyResolver.Installer
{
    /// <summary>
    ///     Setup service
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
            container.Register(Component.For<IServiceCalculator>().ImplementedBy<ServiceCalculator>());
        }
    }
}