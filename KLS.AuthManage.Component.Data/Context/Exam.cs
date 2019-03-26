namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exam")]
    public partial class Exam
    {
        [StringLength(20)]
        public string ExamId { get; set; }

        [Required]
        [StringLength(100)]
        public string ExamName { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string SchemeId { get; set; }

        public int SortIndex { get; set; }

        public bool TrialUsed { get; set; }

        public DateTime AddTime { get; set; }

        public int? UsedCount { get; set; }

        public int? Flag { get; set; }
    }
}
