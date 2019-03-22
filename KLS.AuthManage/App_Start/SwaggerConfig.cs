using System.Web.Http;
using WebActivatorEx;
using KLS.AuthManage;
using Swashbuckle.Application;
using System.Globalization;
using KLS.AuthManage.Providers;
using KLS.AuthManage.App_Start;
using System.Linq;

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
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                    c.DocumentFilter<InjectMiniProfiler>();
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.MultipleApiVersions((apiDesc, version) =>{
                    var path = apiDesc.RelativePath.Split('/');
                    var pathVersion = path[1];
                    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(pathVersion, version, CompareOptions.IgnoreCase) >= 0;
                },vc =>{vc.Version("v1", "½Ó¿Ú");});
                    GetXmlCommentsPath();
                })
                .EnableSwaggerUi(c =>
                {
                    string resourceName = thisAssembly.FullName.Substring(0, thisAssembly.FullName.IndexOf(",")) + ".Scripts.swaggerui.swagger_lang.js";
                    c.InjectJavaScript(thisAssembly, resourceName);

                    string resourceName2 = thisAssembly.FullName.Substring(0, thisAssembly.FullName.IndexOf(",")) + ".Scripts.swaggerui.SwaggerUiCustomization.js";
                    c.InjectJavaScript(thisAssembly, resourceName2);
                });
        }
    }
}