namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScanVideo")]
    public partial class ScanVideo
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string CourseId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        public int? Sort { get; set; }

        [StringLength(50)]
        public string TencentAPPID { get; set; }

        [StringLength(50)]
        public string TencentID { get; set; }

        public DateTime? AddTime { get; set; }
    }
}
