using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.IService.IHzwxService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.HzwxService
{
    public class VideoExamService : IVideoExamService
    {
        private readonly IHDbServiceReposity _dbServiceReposity;

        public VideoExamService(IHDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<VideoExam> GetAllVideoExams()
        {
            return _dbServiceReposity.All<VideoExam>().ToList();
        }

        public List<VideoExam> GetVideoExamByChapSecId(string chapSecId)
        {
            return _dbServiceReposity.Where<VideoExam>(d => d.ChapSecId == chapSecId).ToList();
        }

        public List<VideoExam> GetVideoExamByCourseId(string courseId)
        {
            return _dbServiceReposity.Where<VideoExam>(d => d.CourseID == courseId).ToList();
        }
    }
}
