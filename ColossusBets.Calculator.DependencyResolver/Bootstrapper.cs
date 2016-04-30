using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ColossusBets.Calculator.DependencyResolver
{
    /// <summary>
    ///     Bootstrapper
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        ///     Bootstrap the IoC
        /// </summary>
        /// <returns>Returns a configured IoC</returns>
        public static IWindsorContainer Boot()
        {
            return new WindsorContainer().Install(FromAssembly.InThisApplication());
        }

        /// <summary>
        ///     Bootstrap the IoC
        /// </summary>
        /// <param name="folder">Folder into which installers are searched</param>
        /// <returns>Returns a configured IoC</returns>
        public static IWindsorContainer Boot(string folder)
        {
            var container = new WindsorContainer().Install(FromAssembly.InDirectory(new AssemblyFilter(folder)));
            return container;
        }
    }
}