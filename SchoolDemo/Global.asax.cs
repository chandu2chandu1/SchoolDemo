using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using SchoolDemo.Controllers;
using SchoolDemo.api;
using SchoolDemo.Core;
using SchoolDemo.Core.Repositories;
using SchoolDemo.Models;

namespace SchoolDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerDependency();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            var container = builder.Build();
            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
