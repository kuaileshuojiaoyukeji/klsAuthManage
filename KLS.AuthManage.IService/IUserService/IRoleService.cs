using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.Member;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IUserService
{
    public interface IRoleService
    {
        Task<OperationResult> InsertAsync(RoleModel model);
        Task<OperationResult> UpdateAsync(RoleModel model);
        OperationResult Delete(IEnumerable<RoleModel> list);
        IList<ZTreeVM> GetListZTreeVM(int id);
        Task<OperationResult> UpdateAuthorize(int roleId, int[] ids);
    }
}
