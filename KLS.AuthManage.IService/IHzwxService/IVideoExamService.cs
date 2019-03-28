using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IHzwxService
{
    public interface IVideoExamService
    {
        /// <summary>
        /// 获取所有VideoExams
        /// </summary>
        /// <returns></returns>
        List<VideoExam> GetAllVideoExams();

        /// <summary>
        /// 根据章节id获取对应的VideoExams
        /// </summary>
        /// <param name="chapSecId">章节id</param>
        /// <returns></returns>
        List<VideoExam> GetVideoExamByChapSecId(string chapSecId);

        /// <summary>
        /// 根据课程id获取对应的VideoExams
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        List<VideoExam> GetVideoExamByCourseId(string courseId);
    }
}
