namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionType")]
    public partial class QuestionType
    {
        [Key]
        [StringLength(20)]
        public string TypeId { get; set; }

        [Required]
        [StringLength(80)]
        public string TypeName { get; set; }

        [Required]
        [StringLength(20)]
        public string ControlType { get; set; }

        public bool IsComplex { get; set; }

        public int SortIndex { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }
    }
}
