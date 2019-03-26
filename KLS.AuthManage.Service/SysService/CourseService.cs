using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.SysService
{
    public class CourseService : ICourseService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public CourseService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<Course> GetCoursesByCertificateId(string certId)
        {
            return _dbServiceReposity.Where<Course>(d => d.CertId == certId).ToList();
        }
    }
}
