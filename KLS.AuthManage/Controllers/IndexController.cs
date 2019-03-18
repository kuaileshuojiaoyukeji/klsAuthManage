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
using System.Web.Http;

namespace KLS.AuthManage.Controllers
{
    [Authorize]
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
            string userId = User.Identity.GetUserName();
            int id = User.Identity.GetUserId<int>();
            return userId + id.ToString();
        }

        /// <summary>
        /// 新增Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertTests")]
        public string InsertTests(TestViewModel model)
        {
            //string userId = User.Identity.GetUserName();
            //int id = User.Identity.GetUserId<int>();
            SysTest sysTest = new SysTest
            {
                //注意:不设置该字段或者匿名接口访问时该操作员id字段数据为0
                CreatorID = User.Identity.GetUserId<int>(),
                TestName = model.TestName
            };
            return _sysPowerService.InsertTest(sysTest).ToString();
        }

        /// <summary>
        /// 获取所有Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetTests")]
        public List<SysTest> GetTests()
        {
            return _sysPowerService.GetTestList();
        }

        /// <summary>
        /// 新增Test对象
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertOnly")]
        public string InsertOnly(TestViewModel model)
        {
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
