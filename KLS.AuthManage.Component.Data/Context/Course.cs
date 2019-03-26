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
        [StringLength(20)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(80)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(10)]
        public string AbbrevName { get; set; }

        public int SortIndex { get; set; }

        [Required]
        [StringLength(20)]
        public string CertId { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }

        [StringLength(200)]
        public string PageURL { get; set; }

        [StringLength(200)]
        public string CourseLogo { get; set; }
    }
}
