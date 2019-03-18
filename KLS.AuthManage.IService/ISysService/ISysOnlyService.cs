using KLS.AuthManage.Data.Model.SysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface ISysOnlyService
    {
        int InsertOnly(SysOnly only);
    }
}
