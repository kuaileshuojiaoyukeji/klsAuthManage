using KLS.AuthManage.Component.Data.Initialize;
using KLS.AuthManage.Component.Tools.Core.GlobalFilters;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KLS.AuthManage
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalFilters.Filters.Add(new ApiExpLogFilter());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MiniProfilerEF6.Initialize();
            DatabaseInitializer.Initialize();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultContext"].ToString();
            System.Data.SqlClient.SqlDependency.Start(connectionString);
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }
        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
