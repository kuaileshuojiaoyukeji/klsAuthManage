using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.IUserService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.UserService
{
    public class PermissionService : IPermissionService
    {
        public IList<PermissionModel> GetListPermissionByPage()
        {
            throw new NotImplementedException();
        }

        public OperationResult Insert(PermissionModel model)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(PermissionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
