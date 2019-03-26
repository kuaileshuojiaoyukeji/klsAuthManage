namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        public int SubjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        public int? Sort { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public bool? IsShow { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public bool? IsProxy { get; set; }

        [StringLength(50)]
        public string SubjectClass { get; set; }
    }
}
