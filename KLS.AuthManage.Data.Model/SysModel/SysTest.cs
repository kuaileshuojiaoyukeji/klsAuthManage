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
    [Description("测试类")]
    [Table("Sys_Test")]
    public class SysTest :EntityBase<int>
    {
        [Required]
        [StringLength(30)]
        [Description("测试名称")]
        public string TestName { get; set; }

        [StringLength(30)]
        [Description("测试初始化")]
        public string ChuShiHua { get; set; }
    }
}
