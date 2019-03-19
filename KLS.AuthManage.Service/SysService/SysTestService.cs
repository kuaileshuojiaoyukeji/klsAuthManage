using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Component.Tools.Core.LinqExtent;
using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public List<SysTest> GetTestListByPage(int pageIndex, int pagesize, List<SysTest> sysTests)
        {
            return _dbServiceReposity.SelectPageList(pageIndex, pagesize, sysTests);
        }

        public int InsertTest(SysTest user)
        {
            return _dbServiceReposity.Add(user);
        }

        public List<SysTest> SelectByParams(SysTest sysTest, int page, int size = 20)
        {
            return _dbServiceReposity.All<SysTest>().Where(sysTest).ToList();
        }

        public List<TestVM> SelectNames(int id, out int count)
        {
            count = 0;
            SqlParameter prmTotal = new SqlParameter("@count", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var _list = _dbServiceReposity.Query<TestVM>("exec select_testNames @id, @count out", new SqlParameter("@id", id), prmTotal);
            count = (int)prmTotal.Value;
            return _list;
        }
    }
}
