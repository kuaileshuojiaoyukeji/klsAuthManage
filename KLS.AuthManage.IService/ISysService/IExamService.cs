using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface IExamService
    {
        /// <summary>
        /// 根据章节id获取对应的试卷
        /// </summary>
        /// <param name="chapterSectionId"></param>
        /// <returns></returns>
        List<Exam> GetExamsByChapterSectionId(string chapterSectionId);

        /// <summary>
        /// 根据课程id获取对应的试卷
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Exam> GetExamsByCourseId(string courseId);
    }
}
