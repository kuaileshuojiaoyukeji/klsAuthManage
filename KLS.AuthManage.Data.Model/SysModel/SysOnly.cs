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
    [Description("测试类01")]
    [Table("Sys_Only")]
    public class SysOnly : EntityBaseBasics<int>
    {
        [Required]
        [StringLength(30)]
        [Description("测试名称")]
        public string OnlyName { get; set; }
    }
}
