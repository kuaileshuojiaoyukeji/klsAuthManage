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
    public class ExamService : IExamService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public ExamService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<Exam> GetExamsByChapterSectionId(string chapterSectionId)
        {
            return _dbServiceReposity.Where<Exam>(d => d.ExamId == chapterSectionId).ToList();
        }

        public List<Exam> GetExamsByCourseId(string courseId)
        {
            //通过课程获取试卷 先获取课程下的章节id在获取这些章节id下的试卷
            //List<string> _chapterSectionIds = _dbServiceReposity.Where<ChapterSection>(d => d.CourseId == courseId).Select(d => d.ChapSecId).ToList();
            return _dbServiceReposity.Where<Exam>(d=> d.CourseId == courseId).ToList();
        }
    }
}
