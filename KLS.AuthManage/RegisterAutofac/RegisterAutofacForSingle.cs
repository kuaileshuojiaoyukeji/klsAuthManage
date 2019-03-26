using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Component.Tools.Configs;
using KLS.AuthManage.Data.Model.Member;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace KLS.AuthManage.RegisterAutofac
{
    public class RegisterAutofacForSingle
    {
        public static void RegisterAutofac(IAppBuilder app)
        {
            ContainerBuilder builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            builder.Register(o => new DbServiceReposity(new hzwxdb())).As<IDbServiceReposity>().InstancePerLifetimeScope();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider(); //开启了Filter的依赖注入功能，为过滤器使用属性注入必须在容器创建之前调用RegisterFilterProvider方法，并将其传到AutofacDependencyResolver
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User, int>>().InstancePerRequest();
            builder.Register(o => new ApplicationRoleStore(new hzwxdb())).InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationRoleStore>().As<UserManager<User, int>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().As<UserManager<User, int>>().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().As<SignInManager<User, int>>().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider());

            #region IOC注册区域

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            #endregion
            #region 自动注入SERVICES
            var interfaces = Assembly.Load("KLS.AuthManage.IService");
            var services = Assembly.Load("KLS.AuthManage.Service");
            builder.RegisterAssemblyTypes(interfaces, services)
                    .Where(s => s.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            builder.RegisterFilterProvider();
            #endregion
            // then
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}