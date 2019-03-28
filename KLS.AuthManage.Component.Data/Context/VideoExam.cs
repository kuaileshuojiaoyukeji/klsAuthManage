namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoExam")]
    public partial class VideoExam
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string ChapSecId { get; set; }

        [StringLength(20)]
        public string ExamID { get; set; }

        public int ChapterID { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(20)]
        public string CourseID { get; set; }

        public int? CourseVideoID { get; set; }

        public int? HZCourseID { get; set; }
    }
}
