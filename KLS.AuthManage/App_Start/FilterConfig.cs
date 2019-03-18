using KLS.AuthManage.AuthFilters;
using KLS.AuthManage.Component.Tools.Core.GlobalFilters;
using System.Web;
using System.Web.Mvc;

namespace KLS.AuthManage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ApiExpLogFilter());
        }
    }
}
