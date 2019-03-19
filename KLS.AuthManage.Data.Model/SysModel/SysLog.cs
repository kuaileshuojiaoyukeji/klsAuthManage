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
    [Description("日志异常类")]
    [Table("T_Log")]
    public class SysLog
    {
        [Key]
        [Display(Name = "日志ID")]
        public int ID { set; get; }

        [Display(Name = "请求用时")]
        [StringLength(50)]
        public string Time_Stamp { set; get; }

        [Display(Name = "日志级别")]
        [StringLength(20)]
        public string Level { set; get; }

        [Display(Name = "机器名")]
        [StringLength(100)]
        public string Host { set; get; }

        [Display(Name = "日志类型")]
        [StringLength(50)]
        public string type { set; get; }

        [Display(Name = "来源")]
        [StringLength(200)]
        public string source { set; get; }

        [Display(Name = "记录人")]
        [StringLength(200)]
        public string logger { set; get; }

        [Display(Name = "控制器")]
        [StringLength(200)]
        public string controller { set; get; }

        [Display(Name = "ACtion")]
        [StringLength(200)]
        public string action { set; get; }

        [Display(Name = "操作人")]
        [StringLength(200)]
        public string loggeruser { set; get; }

        [Display(Name = "参数")]
        [StringLength(200)]
        public string param { set; get; }

        [Display(Name = "日志内容")]
        [StringLength(6000)]
        public string message { set; get; }

        [Display(Name = "异常跟踪")]
        [StringLength(8000)]
        public string stacktrace { set; get; }

        [Display(Name = "异常详细")]
        [StringLength(8000)]
        public string detail { set; get; }
    }
}
