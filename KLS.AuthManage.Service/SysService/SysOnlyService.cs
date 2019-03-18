using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.SysService
{
    public class SysOnlyService : ISysOnlyService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public SysOnlyService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public int InsertOnly(SysOnly only)
        {
            return _dbServiceReposity.Add(only);
        }
    }
}
