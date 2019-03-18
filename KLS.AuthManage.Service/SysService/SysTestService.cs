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
    public class SysTestService: ISysTestService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public SysTestService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<SysTest> GetTestList()
        {
            return _dbServiceReposity.All<SysTest>().ToList();
        }

        public int InsertTest(SysTest user)
        {
            return _dbServiceReposity.Add(user);
        }
    }
}
