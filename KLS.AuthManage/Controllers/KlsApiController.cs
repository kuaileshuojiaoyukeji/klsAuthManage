using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.ISysService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KLS.AuthManage.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/v1/KlsApi")]
    public class KlsApiController : BaseController
    {
        private readonly ICertificateService _certificateService;
        private readonly ICourseService _courseService;
        private readonly IChapterSectionService _chapterSectionService;
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;

        public KlsApiController(IQuestionOptionService questionOptionService, IQuestionService questionService, IExamService examService, IChapterSectionService chapterSectionService, ICourseService courseService, ICertificateService certificateService)
        {
            _certificateService = certificateService;
            _courseService = courseService;
            _chapterSectionService = chapterSectionService;
            _examService = examService;
            _questionOptionService = questionOptionService;
            _questionService = questionService;
        }

        /// <summary>
        /// 用户对应的科目列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAllCertificates")]
        public List<Certificate> GetAllCertificates()
        {
            return _certificateService.SelectAllCertificates();
        }

        /// <summary>
        /// 根据科目id获取科目信息 
        /// </summary>
        /// <param name="certificateId">科目id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCertificateById")]
        public Certificate GetCertificateById(string certificateId)
        {
            return _certificateService.SelectCertificateById(certificateId);
        }

        /// <summary>
        /// 根据科目id获取对应课程列表
        /// </summary>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetCoursesByCertificateId")]
        public List<Course> GetCoursesByCertificateId(string certificateId)
        {
            return _courseService.GetCoursesByCertificateId(certificateId);
        }

        /// <summary>
        /// 根据课程id获取对应章节列表
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChapterSectionByCourseId")]
        public List<ChapterSectionModel> GetChapterSectionByCourseId(string courseId)
        {
            //递归
            var _list = _chapterSectionService.GetChapterSectionByCourseId(courseId);
            //获取章进行排序
            var fatherChapterSections = _list.Where(d => d.LevelIndex == 0).OrderBy(d=>d.SortIndex).ToList();
            var chapterSectionModels = new List<ChapterSectionModel>();
            if (fatherChapterSections.Count > 0)
            {
                foreach (var chapterSection in fatherChapterSections)
                {
                    var chapterSectionModel = new ChapterSectionModel
                    {
                        ChapSecId = chapterSection.ChapSecId,
                        ChapSecName = chapterSection.ChapSecName,
                        CourseId = chapterSection.CourseId,
                        ItemCount = chapterSection.ItemCount,
                        LevelIndex = chapterSection.LevelIndex,
                        ParentId = chapterSection.ParentId,
                        SortIndex = chapterSection.SortIndex,
                        TrialUsed = chapterSection.TrialUsed
                    };
                    //获取章下的节并排序
                    var childlist = (from l in _list
                                     where l.ParentId == chapterSection.ChapSecId
                                     && l.LevelIndex == 1
                                     orderby l.LevelIndex
                                     select new ChapterSectionModel
                                     {
                                         ChapSecId = l.ChapSecId,
                                         ChapSecName = l.ChapSecName,
                                         CourseId = l.CourseId,
                                         ItemCount = l.ItemCount,
                                         LevelIndex = l.LevelIndex,
                                         ParentId = l.ParentId,
                                         SortIndex = l.SortIndex,
                                         TrialUsed = l.TrialUsed
                                     }).ToList();

                    chapterSectionModel.ChapterSectionModels = childlist;
                    chapterSectionModels.Add(chapterSectionModel);
                }
            }
            return chapterSectionModels;
        }

        /// <summary>
        /// 根据章节id获取对应的试卷
        /// </summary>
        /// <param name="chapterSectionId">章节id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetExamsByChapterSectionId")]
        public List<Exam> GetExamsByChapterSectionId(string chapterSectionId)
        {
            return _examService.GetExamsByChapterSectionId(chapterSectionId);
        }

        /// <summary>
        /// 根据课程id获取对应的试卷
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetExamsByCourseId")]
        public List<Exam> GetExamsByCourseId(string courseId)
        {
            return _examService.GetExamsByCourseId(courseId);
        }

        /// <summary>
        /// 根据章节id也是试卷id获取试题及选项
        /// </summary>
        /// <param name="examId">章节id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetQuestionsByExamId")]
        public List<QuestionModel> GetQuestionsByExamId(string examId)
        {
            var list = _questionService.GetQuestionsByExamId(examId);
            return null;
            //return _examService.GetExamsByCourseId(courseId);
        }
    }
}
