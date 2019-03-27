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

        public List<Course> GetCoursesByCertificateIdSql(string certId, int pageIndex, int pagesize)
        {
            string strSQL = string.Format(@"SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER(ORDER BY  SortIndex) AS num FROM dbo.Course) a
                                        WHERE CertId = '{0}' AND a.num BETWEEN ({1}-1)*{2}+1 AND ({1})*{2}",
                                        certId, pageIndex, pagesize);
            return _dbServiceReposity.Query<Course>(strSQL);
        }
    }
}
