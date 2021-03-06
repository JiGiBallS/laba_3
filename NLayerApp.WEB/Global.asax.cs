using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NLayerApp.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule employeeModule = new EmployeeModule();
            NinjectModule serviceModule = new ServiceModule("ShopConnection");
            var kernel = new StandardKernel(employeeModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
