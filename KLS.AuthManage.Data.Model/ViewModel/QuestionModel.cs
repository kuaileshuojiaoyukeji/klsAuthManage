using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    public class QuestionModel
    {
        public string QuestionId { get; set; }

        public string CourseId { get; set; }

        public string CategoryId { get; set; }

        public string ExamId { get; set; }

        public string Title { get; set; }

        public string TitleTopic { get; set; }

        public string TopicId { get; set; }

        public string TypeId { get; set; }

        public string Answer { get; set; }

        public string Analysis { get; set; }

        public double? Score { get; set; }

        public int SortIndex { get; set; }

        public string KeyGuid { get; set; }

        public string Video { get; set; }

        public string PageURL { get; set; }

        public List<QuestionOptionModel> QuestionOptionModels{ get; set; }
}
}
