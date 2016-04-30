using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using ColossusBets.Calculator.Api.Castle;
using ColossusBets.Calculator.DependencyResolver;

namespace ColossusBets.Calculator.Api
{
    public class WebApiApplication : HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Web API Castle Windsor
            _container = Bootstrapper.Boot(AppDomain.CurrentDomain.BaseDirectory + "/bin");
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(_container);
        }

        protected void Application_End()
        {
            _container.Dispose();
            Dispose();
        }
    }
}