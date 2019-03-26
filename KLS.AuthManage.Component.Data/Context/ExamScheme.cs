namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamScheme")]
    public partial class ExamScheme
    {
        [Key]
        [StringLength(20)]
        public string SchemeId { get; set; }

        [Required]
        [StringLength(100)]
        public string SchemeName { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseId { get; set; }

        public int TotalTimeTicks { get; set; }

        public double TotalScore { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }
    }
}
