using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface ISysTestService
    {
        List<SysTest> GetTestList();
        int InsertTest(SysTest user);
        List<SysTest> GetTestListByPage(int pageIndex, int pagesize, List<SysTest> sysTests);
        List<TestVM> SelectNames(int id, out int count);
    }
}
