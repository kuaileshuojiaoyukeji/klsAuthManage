using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.SysModel;
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
    public class ModuleService : IModuleService
    {
        public OperationResult Delete(IEnumerable<ModuleModel> list)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SysModule> GetEntitiesByEager(IEnumerable<string> inclueList)
        {
            throw new NotImplementedException();
        }

        public IList<ModuleModel> GetListModuleByPage()
        {
            throw new NotImplementedException();
        }

        public OperationResult Insert(ModuleModel model)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(ModuleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
