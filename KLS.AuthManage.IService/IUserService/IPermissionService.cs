using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IUserService
{
    public interface IPermissionService
    {
        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <returns></returns>
        IList<PermissionModel> GetListPermissionByPage();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Insert(PermissionModel model);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Update(PermissionModel model);
    }
}
