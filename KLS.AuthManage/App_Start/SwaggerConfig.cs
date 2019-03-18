using System.Web.Http;
using WebActivatorEx;
using KLS.AuthManage;
using Swashbuckle.Application;
using System.Globalization;
using KLS.AuthManage.Providers;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace KLS.AuthManage
{
    public class SwaggerConfig
    {
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/KLS.AuthManage.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.OperationFilter<AddAuthorizationHeader>();
                    c.MultipleApiVersions((apiDesc, version) =>{
                    var path = apiDesc.RelativePath.Split('/');
                    var pathVersion = path[1];
                    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(pathVersion, version, CompareOptions.IgnoreCase) >= 0;
                },vc =>{vc.Version("v1", "½Ó¿Ú");});
                    GetXmlCommentsPath();
                })
                .EnableSwaggerUi();
        }
    }
}