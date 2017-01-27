using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Warehouse.BLL.Infrastructure;
using Warehouse.Web.Infrastructure;

namespace Warehouse.Web
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            // REGISTER MODULS
            builder.RegisterModule(new AutofacModule());
            builder.RegisterModule(new AutofacWebModule());

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // REGISTER DEPENDENCIES
            // Web dependencies here.

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}