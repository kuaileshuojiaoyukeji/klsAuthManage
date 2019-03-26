namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [StringLength(20)]
        public string QuestionId { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string ExamId { get; set; }

        [Required]
        [StringLength(4000)]
        public string Title { get; set; }

        [StringLength(200)]
        public string TitleTopic { get; set; }

        [StringLength(20)]
        public string TopicId { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeId { get; set; }

        [StringLength(400)]
        public string Answer { get; set; }

        public string Analysis { get; set; }

        public double? Score { get; set; }

        public int SortIndex { get; set; }

        public DateTime AddTime { get; set; }

        [StringLength(50)]
        public string KeyGuid { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        [StringLength(250)]
        public string PageURL { get; set; }
    }
}
