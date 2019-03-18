using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
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
    //[Authorize]
    [RoutePrefix("api/v1/SysUser")]
    public class SysUserController : ApiController
    {
        private readonly IAuthService _authService;
        public SysUserController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 当前用户个人信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FindUserById")]
        public async Task<User> FindUserById()
        {
            int id = User.Identity.GetUserId<int>();
            var user = await _authService.FindUserById(id);
            //var _user = from u in user
            //            select new
            //            {

            //            };
            return user;
        }

        /// <summary>
        /// 获取用户所有权限名称
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserRoleNameByIds")]
        public async Task<List<string>> GetUserRoleNameByIds()
        {
            IList<string> _list = await _authService.GetUserRoleNameByIds(User.Identity.GetUserId<int>());
            return _list.ToList();
        }

        /// <summary>
        /// 新增用户假设需要超级权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("InsertUser")]
        //[Authorize(Roles = "super,admin")]
        public async Task<bool> InsertUser(UserVM model)
        {
            User _users = new User()
            {
                UserName = model.UserName,
                Address = model.Address,
                CertificateNo = model.CertificateNo,
                Email = model.Email,
                Enabled = model.Enabled,
                PasswordHash = model.Password,
                Phone = model.Phone,
                TrueName = model.TrueName,
                CreateTime = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            return await _authService.Register(_users);
        }

        /// <summary>
        /// 设置或更新用户角色
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="roleIds">角色Id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUserRoles")]
        public async Task<bool> UpdateUserRoles(int userId, string roleIds)
        {
            string[] sArray = roleIds.Split(',');
            int[] idInts = Array.ConvertAll<string, int>(sArray, Convert.ToInt32);
            return await _authService.UpdateRolesById(userId, idInts);
        }
    }
}
