namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseItemChapter")]
    public partial class CourseItemChapter
    {
        [Key]
        public int ChapterID { get; set; }

        [Required]
        [StringLength(200)]
        public string ChapterName { get; set; }

        public int? Sort { get; set; }

        public int? CourseItemID { get; set; }

        public int? Payment { get; set; }

        public int? ItemCount { get; set; }

        public int? ParentID { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
