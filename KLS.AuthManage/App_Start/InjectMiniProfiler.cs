using StackExchange.Profiling;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace KLS.AuthManage.App_Start
{
    public class InjectMiniProfiler : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.info.contact = new Contact()
            {
                name = MiniProfiler.RenderIncludes().ToHtmlString()
            };
        }
    }
}