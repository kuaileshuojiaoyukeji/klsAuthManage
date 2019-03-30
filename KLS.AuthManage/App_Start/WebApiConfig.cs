using KLS.AuthManage.AuthFilters;
using KLS.AuthManage.Component.Tools.Core.GlobalFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KLS.AuthManage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //config.SuppressDefaultHostAuthentication();
            //跨域配置
            //config.EnableCors();
            // Web API 路由
            config.MapHttpAttributeRoutes();
            //config.Filters.Add(new AuthorizeFilter());
            config.Filters.Add(new ApiResultAttribute());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
