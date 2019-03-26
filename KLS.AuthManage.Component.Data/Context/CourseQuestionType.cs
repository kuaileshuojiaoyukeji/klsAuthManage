namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseQuestionType")]
    public partial class CourseQuestionType
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string TypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public bool VarScore { get; set; }

        public int SortIndex { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }
    }
}
