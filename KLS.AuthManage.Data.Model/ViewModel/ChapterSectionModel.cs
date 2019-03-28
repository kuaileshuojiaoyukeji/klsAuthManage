using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    public class ChapterSectionModel
    {
        public string ChapSecId { get; set; }

        public string ChapSecName { get; set; }

        public string CourseId { get; set; }

        public string VideoUrl { get; set; }
        //public string ParentId { get; set; }

        //public int LevelIndex { get; set; }

        //public bool TrialUsed { get; set; }

        //public int SortIndex { get; set; }

        //public int? ItemCount { get; set; }

        public List<ChapterSectionModel> ChapterSectionModels { get; set; }
    }
}
