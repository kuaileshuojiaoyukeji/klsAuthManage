namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Certificate")]
    public partial class Certificate
    {
        [Key]
        [StringLength(20)]
        public string CertId { get; set; }

        [Required]
        [StringLength(80)]
        public string CertName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastVersion { get; set; }

        [Required]
        [StringLength(100)]
        public string DownloadUrl { get; set; }

        public int SortIndex { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }
    }
}
