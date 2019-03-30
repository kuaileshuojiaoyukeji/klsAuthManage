using KLS.AuthManage.Component.Tools.Helpers;
using KLS.AuthManage.Data.Model.Member;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KLS.AuthManage.Component.Tools.Core.GlobalFilters
{
    //弃用
    public class ApiExpLogFilter : HandleErrorAttribute
    {
        protected string _errorMsg = string.Empty;
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var exception = filterContext.Exception;
            string sbExMsg = ExceptionExt.ExceptionMsg(exception);
            Exception exp = filterContext.Exception;
            Type ex = filterContext.Exception.GetType();
            //bool eh = true;
            if (ex.Name == "DbUpdateConcurrencyException")
            {
                var e = filterContext.Exception as DbUpdateConcurrencyException;
                var entry = e.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    _errorMsg = "无法保存更改，系已经被其他用户删除.";
                    //filterContext.Result = Failure(_errorMsg);
                }
                else
                {
                    _errorMsg = "无法保存更改，当前记录已经被其他人更改.";
                    //filterContext.Result = Failure(_errorMsg);
                }
            }

            LogEventInfo ei = new LogEventInfo(LogLevel.Error, "", sbExMsg);
            ei.Properties["stacktrace"] = exception.ExceptionStackTrace();
            LogHelper.LogException(ei);
            //告诉MVC框架异常被处理
            filterContext.ExceptionHandled = false;
        }

        public JsonResult Failure(string _msg = "操作失败")
        {
            return null;
        }
    }
}
