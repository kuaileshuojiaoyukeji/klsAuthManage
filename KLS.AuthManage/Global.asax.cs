using KLS.AuthManage.Component.Tools.Core.GlobalFilters;
using KLS.AuthManage.Component.Tools.Core.Initialize;
using KLS.AuthManage.Component.Tools.Helpers;
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
            
        }

        protected void Application_BeginRequest()
        {
            LogHelper.LogInfo("5");
            if (Request.IsLocal)
            {
                LogHelper.LogInfo("6");
                MiniProfiler.Start();
                LogHelper.LogInfo("7");
            }
        }
        protected void Application_EndRequest()
        {
            LogHelper.LogInfo("8");
            MiniProfiler.Stop();
        }
    }
}
