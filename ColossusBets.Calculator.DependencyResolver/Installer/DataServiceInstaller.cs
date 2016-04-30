using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ColossusBets.Calculator.DataService;
using ColossusBets.Calculator.DataService.Ef6;
using ColossusBets.Calculator.DataService.Ef6.Context;

namespace ColossusBets.Calculator.DependencyResolver.Installer
{
    /// <summary>
    ///     Setup service
    /// </summary>
    public class DataServiceInstaller : IWindsorInstaller
    {
        /// <summary>
        ///     Registers components into Castle
        /// </summary>
        /// <param name="container">Container</param>
        /// <param name="store">Store</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDataServiceCalculator>().ImplementedBy<DataServiceCalculator>());
            container.Register(Component.For<IDbContext>().ImplementedBy<CalculatorContext>());
        }
    }
}