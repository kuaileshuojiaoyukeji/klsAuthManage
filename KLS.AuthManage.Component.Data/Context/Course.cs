namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int CourseID { get; set; }

        [StringLength(50)]
        public string CourseGuid { get; set; }

        [StringLength(100)]
        public string CourseName { get; set; }

        public int? Sort { get; set; }

        public DateTime? CreateTime { get; set; }

        public bool? Disabled { get; set; }

        public int? SubjectID { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
