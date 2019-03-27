using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.SysModel
{
    [Description("外部公司用户与科目关联表")]
    [Table("Sys_UserCertificate")]
    public class SysUserCertificate
    {
        [Display(Name = "主键Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "用户Id")]
        public int UserId  { get; set; }
        [Display(Name = "科目Id")]
        [StringLength(500)]
        public string CertificateId { get; set; }
    }
}
