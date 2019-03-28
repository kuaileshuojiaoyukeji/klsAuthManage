using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IHzwxService
{
    public interface IScanVideoService
    {
        /// <summary>
        /// 通过VideoExam的HZCourseID获取ScanVideo的TencentID用来获取章节对应视频
        /// </summary>
        /// <param name="hZCourseID">?</param>
        /// <returns></returns>
        ScanVideo GetScanVideoByHZCourseID(int hZCourseID);
    }
}
