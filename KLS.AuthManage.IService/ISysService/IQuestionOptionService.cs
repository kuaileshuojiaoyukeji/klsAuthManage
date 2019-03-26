using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface IQuestionOptionService
    {
        /// <summary>
        /// 获取所有试题的选项
        /// </summary>
        /// <returns></returns>
        List<QuestionOption> GetAllQuestionOptions();

        /// <summary>
        /// 根据试题id获取对应的试题选项
        /// </summary>
        /// <param name="questionId">试题Id</param>
        /// <returns></returns>
        List<QuestionOption> GetQuestionOptionsById(string questionId);

        /// <summary>
        /// 获取课程下的所有试题的选项 用此缩短查询时间
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<QuestionOption> GetQuestionOptionsByCourseId(string courseId);
    }
}
