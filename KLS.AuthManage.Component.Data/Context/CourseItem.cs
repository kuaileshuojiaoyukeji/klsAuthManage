namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseItem")]
    public partial class CourseItem
    {
        public int CourseItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseItemName { get; set; }

        public int Sort { get; set; }

        public int? Year { get; set; }

        [StringLength(20)]
        public string Area { get; set; }

        [Column(TypeName = "money")]
        public decimal? OriginalPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? CoursePrice { get; set; }

        public DateTime? ServiceTimeStart { get; set; }

        public DateTime? ServiceTimeEnd { get; set; }

        public bool? Disabled { get; set; }

        public int? CourseID { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
    }
}
