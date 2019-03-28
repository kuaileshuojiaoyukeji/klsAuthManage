using KLS.AuthManage.Component.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace KLS.AuthManage.Controllers
{
    /// <summary>
    /// 基类Controller
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 分页默认每页显示的数量
        /// </summary>
        public readonly int PAGE_SIZE = 20;

        /// <summary>
        /// 学习视频UrlRoot
        /// </summary>
        public readonly string VideoUrlRoot = GlobalConfigHelper.GetVideoUrlRoot();
    }
}
