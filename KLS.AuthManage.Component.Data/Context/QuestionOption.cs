namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionOption")]
    public partial class QuestionOption
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string QuestionId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string OptionId { get; set; }

        [Required]
        [StringLength(500)]
        public string OptionName { get; set; }
    }
}
