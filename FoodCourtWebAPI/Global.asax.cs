using Autofac;
using Autofac.Integration.WebApi;
using BL.AutoMapper;
using DI_AutoFac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FoodCourtWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Auto Mapper Registeration
            AutoMapperConfig.RegisterMappers();
            // DI- dependency injection-AutoFac
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            // Register all api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).AsSelf();
            // Register business objects            
            builder = AutoFaqConfigs.Register(builder);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

        }
        //enable cors origin
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                //Forces all currently buffered output to be sent to the client.
                //The Flush method can be called multiple times during request processing.
                Response.Flush();
            }
        }
    }
}
