using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.IService.IHzwxService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.HzwxService
{
    public class ScanVideoService : IScanVideoService
    {
        private readonly IHDbServiceReposity _dbServiceReposity;

        public ScanVideoService(IHDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public ScanVideo GetScanVideoByHZCourseID(int hZCourseID)
        {
            return _dbServiceReposity.Where<ScanVideo>(d => d.ID == hZCourseID).FirstOrDefault();
        }
    }
}
