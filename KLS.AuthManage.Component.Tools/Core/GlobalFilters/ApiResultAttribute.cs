using KLS.AuthManage.Component.Tools.Attributes;
using KLS.AuthManage.Component.Tools.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Threading;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using StackExchange.Profiling;

namespace KLS.AuthManage.Component.Tools.Core.GlobalFilters
{
    public class ApiResultAttribute : System.Web.Http.Filters.ActionFilterAttribute, IActionFilter
    {
        protected string _errorMsg = string.Empty;
        AuthManage.Data.Model.Member.ResultModel result = null;
        public const string MiniProfilerResultsHeaderName = "X-MiniProfiler-Ids";
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            #region Log01 接口被访问记录
            //log01 type=file
            StringBuilder sb = new StringBuilder();
            sb.Append("PortName:" + actionExecutedContext.Request.RequestUri.AbsolutePath);//获得调用接口
            sb.AppendLine();
            sb.Append("RequestType:" + actionExecutedContext.Request.Method.ToString());
            sb.AppendLine();
            sb.Append("StatusCode:" + Convert.ToInt32(new HttpResponseMessage(HttpStatusCode.OK).StatusCode).ToString());//设置状态码
            sb.AppendLine();
            sb.Append("ClientIp:" + UtilityHelper.GetUserIp().ToString());
            sb.AppendLine();
            LogHelper.LogInfo(sb.ToString());
            #endregion
            //初始化返回结果
            result = new AuthManage.Data.Model.Member.ResultModel();
            if (actionExecutedContext.Exception != null)
            {
                _errorMsg = "请查看错误日志";
                if (actionExecutedContext.Exception.GetType().Name == "DbUpdateConcurrencyException")
                {
                    var e = actionExecutedContext.Exception as DbUpdateConcurrencyException;
                    var entry = e.Entries.Single();
                    var databaseEntry = entry.GetDatabaseValues();
                    if (databaseEntry == null) { _errorMsg = "无法保存更改，系已经被其他用户删除."; }
                    else { _errorMsg = "无法保存更改，当前记录已经被其他人更改."; }
                }
                #region Log02 内部错误日志记录
                //log02 type=db
                LogEventInfo ei = new LogEventInfo(LogLevel.Error, "action_inside" + _errorMsg, sb.ToString());
                ei.Properties["stacktrace"] = actionExecutedContext.Exception.ExceptionStackTrace();
                ei.Properties["controller"] = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                ei.Properties["action"] = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                ei.Properties["loggeruser"] = HttpContext.Current.User.Identity.GetUserName();
                ei.Properties["param"] = JsonHelper.ToJson(actionExecutedContext.ActionContext.ActionArguments);
                LogHelper.LogException(ei);
                #endregion
                result.StatusCode = HttpStatusCode.InternalServerError;//actionExecutedContext.ActionContext.Response.StatusCode;
                result.IsSuccess = false;
                result.ErrorMsg = _errorMsg;//前端隐藏错误信息 
            }
            else
            {
                // 取得由 API 返回的状态代码
                result.StatusCode = actionExecutedContext.ActionContext.Response.StatusCode;
                var a = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>();
                if (!a.IsFaulted)
                {
                    // 取得由 API 返回的资料
                    result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
                }
                //请求是否成功
                result.IsSuccess = actionExecutedContext.ActionContext.Response.IsSuccessStatusCode;
                result.ErrorMsg = "";
            }
            //结果转为自定义消息格式
            HttpResponseMessage httpResponseMessage = JsonHelper.ToJsonResult(result);
            // 重新封装回传格式
            actionExecutedContext.Response = httpResponseMessage;
            if (GlobalConfigHelper.GetSqlListen() == "yes")//启用sql性能调试
            {
                var MiniProfilerJson = JsonConvert.SerializeObject(new[] { MiniProfiler.Current.Id });
                actionExecutedContext.Response.Content.Headers.Add(MiniProfilerResultsHeaderName, MiniProfilerJson);
            }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var noPackage = actionContext.ActionDescriptor.GetCustomAttributes<UnResultAttribute>();
            if (!noPackage.Any())
            {
                var modelState = actionContext.ModelState;
                if (!modelState.IsValid)
                {
                    string error = string.Empty;
                    foreach (var key in modelState.Keys)
                    {
                        var state = modelState[key];
                        if (state.Errors.Any())
                        {
                            error = state.Errors.First().ErrorMessage;
                            if (error == "")
                            {
                                error += state.Errors.First().Exception.Message ?? "";
                            }
                            #region Log03 参数名或参数值进入时错误日志记录
                            //log03 type=db
                            LogEventInfo ei = new LogEventInfo(LogLevel.Error, "action_outside请查看错误日志", "");
                            ei.Properties["stacktrace"] = error;
                            ei.Properties["controller"] = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                            ei.Properties["action"] = actionContext.ActionDescriptor.ActionName;
                            ei.Properties["loggeruser"] = HttpContext.Current.User.Identity.GetUserName();
                            ei.Properties["param"] = JsonHelper.ToJson(actionContext.ActionArguments);
                            LogHelper.LogException(ei);
                            #endregion
                            result = new AuthManage.Data.Model.Member.ResultModel
                            {
                                StatusCode = HttpStatusCode.InternalServerError,
                                IsSuccess = false,
                                ErrorMsg = "请查看错误日志"
                            };
                            HttpResponseMessage httpResponseMessage = JsonHelper.ToJsonResult(result);
                            actionContext.Response = httpResponseMessage;
                            break;
                        }
                    }
                }
            }
            
        }
    }
}
