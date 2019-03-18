using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.IService.IUserService;
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
    [RoutePrefix("api/v1/role")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController() { }
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("InsertRole")]
        public async Task<OperationResult> InsertRole(RoleModel roleModel)
        {
            return await _roleService.InsertAsync(roleModel);
        }
    }
}
