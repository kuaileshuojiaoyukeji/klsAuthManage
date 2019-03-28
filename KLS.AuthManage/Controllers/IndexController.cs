using KLS.AuthManage.Component.Tools.Helpers;
using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.ISysService;
using KLS.AuthManage.IService.IUserService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;

namespace KLS.AuthManage.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/v1/index")]
    public class IndexController : BaseController
    {
        private readonly ISysTestService _sysPowerService;
        private readonly ISysOnlyService _sysOnlyService;
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;
        public IndexController(IRoleService roleService, IAuthService authService,ISysOnlyService sysOnlyService, ISysTestService sysPowerService)
        {
            _sysPowerService = sysPowerService;
            _sysOnlyService = sysOnlyService;
            _authService = authService;
            _roleService = roleService;
        }

        [HttpPost]
        [Route("GetStrings")]
        public string GetStrings()
        {
            LogHelper.LogInfo("a6");
            string userId = User.Identity.GetUserName();
            LogHelper.LogInfo("a7");
            //int id = User.Identity.GetUserId<int>();
            return "";
        }

        /// <summary>
        /// 新增Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertTests")]
        public int InsertTests(TestViewModel model)
        {
            //string userId = User.Identity.GetUserName();存储过程 分页 事务
            //int id = User.Identity.GetUserId<int>();
            //int nn = Convert.ToInt32("dd");
            SysTest sysTest = new SysTest
            {
                //注意:不设置该字段或者匿名接口访问时该操作员id字段数据为0
                CreatorID = User.Identity.GetUserId<int>(),
                TestName = model.TestName
            };
            int num = -1;
            using (TransactionScope transaction = new TransactionScope())
            {
                num = _sysPowerService.InsertTest(sysTest);
                //测试事务
                num = _sysPowerService.InsertTest(sysTest);
                //int nn = Convert.ToInt32("dd");
                transaction.Complete();
            }

            return num;
        }

        /// <summary>
        /// 获取所有Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetTests")]
        public List<SysTest> GetTests(int page, int size = 20)
        {
            var models = _sysPowerService.GetTestList();
            
            //var list = from model in models
            //           select new
            //           {
            //               name = model.TestName
            //           };
            return _sysPowerService.GetTestListByPage(page, size, models);
        }

        /// <summary>
        /// 获取所有Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetTestVM")]
        public List<SysTest> GetTestVM(SysTest testVM, int page, int size = 20)
        {
            return _sysPowerService.SelectByParams(testVM, page, size);
        }

        /// <summary>
        /// sql存储过程测试带输出参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("DoSql")]
        public List<TestVM> DoSql(int id)
        {
            int pStr;
            var models = _sysPowerService.SelectNames(id, out pStr);
            //var list = from model in models
            //           select new
            //           {
            //               name = model.TestName
            //           };
            var dd = pStr;
            return models;
        }

        /// <summary>
        /// 新增Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertOnly")]
        public string InsertOnly(TestViewModel model)
        {
            //这是测试分支
            //string userId = User.Identity.GetUserName();
            //int id = User.Identity.GetUserId<int>();
            SysOnly sysOnly = new SysOnly
            {
                OnlyName = model.TestName
            };
            return _sysOnlyService.InsertOnly(sysOnly).ToString();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("RegisterUser")]
        //[Authorize(Roles = "super,admin")]
        //public async Task<IdentityResult> RegisterUser(UserModel model)
        //{
        //    return await _authService.Register(model);
        //}
    }
}
