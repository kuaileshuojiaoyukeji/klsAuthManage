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

namespace KLS.AuthManage.Component.Tools.Core.GlobalFilters
{
    public class ApiResultAttribute : System.Web.Http.Filters.ActionFilterAttribute, IActionFilter
    {
        AuthManage.Data.Model.Member.ResultModel result = null;
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
            //给文件日志只需一个消息字符串
            LogHelper.LogInfo(sb.ToString());
            #endregion
            //初始化返回结果
            result = new AuthManage.Data.Model.Member.ResultModel();
            if (actionExecutedContext.Exception != null)
            {
                #region Log02 错误日志记录
                //log02 type=db
                LogEventInfo ei = new LogEventInfo(LogLevel.Error, "", sb.ToString());
                ei.Properties["stacktrace"] = actionExecutedContext.Exception.ExceptionStackTrace();
                ei.Properties["controller"] = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                ei.Properties["action"] = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                ei.Properties["loggeruser"] = HttpContext.Current.User.Identity.GetUserName();
                ei.Properties["param"] = JsonHelper.ToJson(actionExecutedContext.ActionContext.ActionArguments);
                LogHelper.LogException(ei);
                #endregion
                result.StatusCode = HttpStatusCode.InternalServerError;//actionExecutedContext.ActionContext.Response.StatusCode;
                result.IsSuccess = false;
                result.ErrorMsg = "请查看错误日志";//前端隐藏错误信息 
                //result.ErrorMsg = actionExecutedContext.Exception.Message;
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
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //var actionDescriptor = actionContext.ActionDescriptor;
            //string controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
            //string actionName = actionDescriptor.ActionName;
            //var actionParams = actionContext.ActionDescriptor.GetParameters();
            //string userName = User.Identity.GetUserId<int>();
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
                            result = new AuthManage.Data.Model.Member.ResultModel
                            {
                                StatusCode = HttpStatusCode.NotFound,
                                IsSuccess = false,
                                ErrorMsg = error
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
