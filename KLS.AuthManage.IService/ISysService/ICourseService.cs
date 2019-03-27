using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface ICourseService
    {
        /// <summary>
        /// 数据列表可在api中linq分页
        /// </summary>
        /// <param name="certId"></param>
        /// <returns></returns>
        List<Course> GetCoursesByCertificateId(string certId);

        /// <summary>
        /// sql处理分页 延时慢时请使用该代码处理
        /// </summary>
        /// <param name="certId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        List<Course> GetCoursesByCertificateIdSql(string certId, int pageIndex, int pagesize);
    }
}
