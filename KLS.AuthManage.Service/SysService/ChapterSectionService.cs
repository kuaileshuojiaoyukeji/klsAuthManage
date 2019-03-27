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
    public class ChapterSectionService : IChapterSectionService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        
        public ChapterSectionService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<ChapterSection> GetChapterSectionByCourseId(string courseId)
        {
            return _dbServiceReposity.Where<ChapterSection>(d => d.CourseId == courseId).ToList();
        }
    }
}
