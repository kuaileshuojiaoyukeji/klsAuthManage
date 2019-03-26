namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamSchemeScore")]
    public partial class ExamSchemeScore
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string SchemeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string TypeId { get; set; }

        public int QuestionCount { get; set; }

        public double ScorePerQuestion { get; set; }

        public double TotalScore { get; set; }

        public int SortIndex { get; set; }
    }
}
