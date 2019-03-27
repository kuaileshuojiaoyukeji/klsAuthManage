using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface IQuestionService
    {
        /// <summary>
        /// 根据试卷id获取试题==模拟考试
        /// </summary>
        /// <param name="examId">试卷id</param>
        /// <returns></returns>
        List<Question> GetQuestionsByExamId(string examId);

        /// <summary>
        /// 根据章节id获取试题==练习
        /// </summary>
        /// <param name="chapterSectionId"></param>
        /// <returns></returns>
        List<Question> GetQuestionsByChapterSectionId(string chapterSectionId);
    }
}
