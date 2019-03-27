using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.SysService
{
    public class QuestionService : IQuestionService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public QuestionService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<Question> GetQuestionsByChapterSectionId(string chapterSectionId)
        {
            return _dbServiceReposity.Where<Question>(d => d.ExamId == chapterSectionId && d.ExamId != "" && d.CategoryId == "Exercise").OrderBy(d => d.SortIndex).ToList();
        }

        public List<Question> GetQuestionsByExamId(string examId)
        {
            return _dbServiceReposity.Where<Question>(d => d.ExamId == examId && d.ExamId != "" && d.CategoryId == "Exam").OrderBy(d => d.SortIndex).ToList();
        }
    }
}
