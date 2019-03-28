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
    /// <summary>
    /// 快乐说对外接口
    /// </summary>
    //[Authorize]
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
        public List<Course> GetCoursesByCertificateId(string certificateId, int pageIndex, int pagesize = 20)
        {
            return _courseService.GetCoursesByCertificateId(certificateId).Take(pagesize * pageIndex).Skip(pagesize * (pageIndex - 1)).ToList();
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
        //[HttpPost]
        //[Route("GetExamsByChapterSectionId")]
        //public List<Exam> GetExamsByChapterSectionId(string chapterSectionId, int pageIndex, int pagesize = 20)
        //{
        //    return _examService.GetExamsByChapterSectionId(chapterSectionId).Take(pagesize * pageIndex).Skip(pagesize * (pageIndex - 1)).ToList();
        //}

        /// <summary>
        /// 根据课程id获取对应的试卷
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetExamsByCourseId")]
        public List<Exam> GetExamsByCourseId(string courseId, int pageIndex, int pagesize = 20)
        {
            return _examService.GetExamsByCourseId(courseId).Take(pagesize * pageIndex).Skip(pagesize * (pageIndex - 1)).ToList(); ;
        }

        /// <summary>
        /// 练习题根据章节id获取试题及选项
        /// </summary>
        /// <param name="chapterSectionId">章节id</param>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetQuestionsByChapterSectionId")]
        public List<QuestionModel> GetQuestionsByChapterSectionId(string chapterSectionId, string courseId)
        {
            List<QuestionModel> _questionModels = null;
            var questionList = _questionService.GetQuestionsByChapterSectionId(chapterSectionId);
            //前期先获取所有的试题选项-后期优化请根据课程获取试题选项在和试题匹配
            var questionOptionList = _questionOptionService.GetQuestionOptionsByCourseId(courseId);
            if (questionList.Count > 0)
            {
                _questionModels = new List<QuestionModel>();
                foreach (var que in questionList)
                {
                    //获取每个试题的选项
                    var questionOption = questionOptionList.Where(d => d.QuestionId == que.QuestionId).OrderBy(d => d.OptionId).ToList();
                    //整合试题
                    var questionModel = new QuestionModel()
                    {
                        Analysis = que.Analysis,
                        Answer = que.Answer,
                        CategoryId = que.CategoryId,
                        ExamId = que.ExamId,
                        //KeyGuid = que.KeyGuid,
                        CourseId = que.CourseId,
                        PageURL = que.PageURL,
                        QuestionId = que.QuestionId,
                        //Score = que.Score,
                        //SortIndex = que.SortIndex,
                        Title = que.Title,
                        TitleTopic = que.TitleTopic,
                        TopicId = que.TopicId,
                        TypeId = que.TypeId,
                        Video = que.Video
                    };
                    var _1uestionOptionModels = new List<QuestionOptionModel>();
                    if (questionOption.Count > 0)
                    {
                        foreach (var _queoption in questionOption)
                        {
                            var questionOptionModel = new QuestionOptionModel()
                            {
                                OptionId = _queoption.OptionId,
                                OptionName = _queoption.OptionName,
                                QuestionId = _queoption.QuestionId
                            };
                            _1uestionOptionModels.Add(questionOptionModel);
                        }
                    }
                    questionModel.QuestionOptionModels = _1uestionOptionModels;
                    _questionModels.Add(questionModel);
                }
            }
            return _questionModels;
        }

        /// <summary>
        /// 模拟考试根据试卷id获取试题及选项
        /// </summary>
        /// <param name="examId">试卷id</param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("GetQuestionsByExamId")]
        //public List<QuestionModel> GetQuestionsByExamId(string examId)
        //{
        //    List<QuestionModel> _questionModels = null;
        //    var questionList = _questionService.GetQuestionsByExamId(examId);
        //    //前期先获取所有的试题选项-后期优化请根据课程获取试题选项在和试题匹配
        //    var questionOptionList = _questionOptionService.GetAllQuestionOptions();
        //    if(questionList.Count > 0)
        //    {
        //        _questionModels = new List<QuestionModel>();
        //        foreach (var que in questionList)
        //        {
        //            //获取每个试题的选项
        //            var questionOption = questionOptionList.Where(d => d.QuestionId == que.QuestionId).OrderBy(d => d.OptionId).ToList();
        //            //整合试题
        //            var questionModel = new QuestionModel()
        //            {
        //                //Analysis = que.Analysis,
        //                //Answer = que.Answer,
        //                CategoryId = que.CategoryId,
        //                ExamId = que.ExamId,
        //                //KeyGuid = que.KeyGuid,
        //                CourseId = que.CourseId,
        //                PageURL = que.PageURL,
        //                QuestionId = que.QuestionId,
        //                //Score = que.Score,
        //                //SortIndex = que.SortIndex,
        //                Title = que.Title,
        //                TitleTopic = que.TitleTopic,
        //                TopicId = que.TopicId,
        //                TypeId = que.TypeId,
        //                Video = que.Video
        //            };
        //            var _1uestionOptionModels = new List<QuestionOptionModel>();
        //            if (questionOption.Count > 0)
        //            {
        //                foreach (var _queoption in questionOption)
        //                {
        //                    var questionOptionModel = new QuestionOptionModel()
        //                    {
        //                        OptionId = _queoption.OptionId,
        //                        OptionName = _queoption.OptionName,
        //                        QuestionId = _queoption.QuestionId
        //                    };
        //                    _1uestionOptionModels.Add(questionOptionModel);
        //                }
        //            }
        //            questionModel.QuestionOptionModels = _1uestionOptionModels;
        //            _questionModels.Add(questionModel);
        //        }
        //    }
        //    return _questionModels;
        //}
    }
}
