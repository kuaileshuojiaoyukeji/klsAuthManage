using KLS.AuthManage.Data.Model.SysModel;
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
    }
}
