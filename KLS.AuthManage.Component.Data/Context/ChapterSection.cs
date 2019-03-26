namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChapterSection")]
    public partial class ChapterSection
    {
        [Key]
        [StringLength(20)]
        public string ChapSecId { get; set; }

        [Required]
        [StringLength(80)]
        public string ChapSecName { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseId { get; set; }

        [StringLength(20)]
        public string ParentId { get; set; }

        public int LevelIndex { get; set; }

        public bool TrialUsed { get; set; }

        public int SortIndex { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }

        public int? ItemCount { get; set; }

        public bool? IsBuy { get; set; }

        public bool? IsSell { get; set; }
    }
}
