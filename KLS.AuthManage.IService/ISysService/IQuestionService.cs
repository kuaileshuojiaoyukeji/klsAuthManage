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
        /// 根据章节id也是试卷id获取试题
        /// </summary>
        /// <param name="examId">章节id</param>
        /// <returns></returns>
        List<Question> GetQuestionsByExamId(string examId);
    }
}
