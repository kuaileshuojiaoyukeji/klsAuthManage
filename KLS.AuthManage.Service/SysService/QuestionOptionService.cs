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
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public QuestionOptionService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }
        public List<QuestionOption> GetAllQuestionOptions()
        {
            return _dbServiceReposity.All<QuestionOption>().ToList();
        }

        public List<QuestionOption> GetQuestionOptionsByCourseId(string courseId)
        {
            return _dbServiceReposity.Where<QuestionOption>(d => d.CourseId == courseId).ToList();
        }

        public List<QuestionOption> GetQuestionOptionsById(string questionId)
        {
            return _dbServiceReposity.Where<QuestionOption>(d=>d.OptionId == questionId).ToList();
        }
    }
}
