using System;
using System.Threading.Tasks;
using KLS.AuthManage.Component.Tools.Configs;
using KLS.AuthManage.Component.Tools.Core.Initialize;
using KLS.AuthManage.Component.Tools.Helpers;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Providers;
using KLS.AuthManage.RegisterAutofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(KLS.AuthManage.Startup))]

namespace KLS.AuthManage
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            RegisterAutofacForSingle.RegisterAutofac(app);
            ConfigureAuth(app);
            DatabaseInitializer.Initialize();
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HZDBContext"].ToString();
            //System.Data.SqlClient.SqlDependency.Start(connectionString);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            // 配置数据库上下文、用户管理器和登录管理器，以便为每个请求使用单个实例
            // app.CreatePerOwinContext(ApplicationDbContext.Create);
            // app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // 使应用程序可以使用 Cookie 来存储已登录用户的信息
            // 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            // 配置登录 Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //LoginPath = new PathString("/Common/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // 当用户登录时使应用程序可以验证安全戳。
                    // 这是一项安全功能，当你更改密码或者向帐户添加外部登录名时，将使用此功能。
                    OnValidateIdentity = SecurityStampValidator
                    .OnValidateIdentity<ApplicationUserManager, User, int>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) =>
                            user.GenerateUserIdentityAsync(manager),
                        getUserIdCallback: (id) => (id.GetUserId<int>()))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // 使应用程序可以在双重身份验证过程中验证第二因素时暂时存储用户信息。
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // 使应用程序可以记住第二登录验证因素，例如电话或电子邮件。
            // 选中此选项后，登录过程中执行的第二个验证步骤将保存到你登录时所在的设备上。
            // 此选项类似于在登录时提供的“记住我”选项。
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(GlobalConfigHelper.GetSessionTimeOut()),
                //AuthorizeEndpointPath = new PathString(""),
                //AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1), //TimeSpan.FromDays(7),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

        }
    }
}
