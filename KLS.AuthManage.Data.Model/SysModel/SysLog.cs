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
    public class SysLog : EntityBaseBasics<int>
    {
        [Display(Name = "请求用时")]
        [StringLength(50)]
        public string TimeStamp { set; get; }

        [Display(Name = "日志级别")]
        [StringLength(20)]
        public string Level { set; get; }

        [Display(Name = "机器名")]
        [StringLength(100)]
        public string Host { set; get; }

        [Display(Name = "日志类型")]
        [StringLength(50)]
        public string LogType { set; get; }

        [Display(Name = "来源")]
        [StringLength(200)]
        public string Source { set; get; }

        [Display(Name = "记录人")]
        [StringLength(200)]
        public string Logger { set; get; }

        [Display(Name = "控制器")]
        [StringLength(200)]
        public string Controller { set; get; }

        [Display(Name = "Action")]
        [StringLength(200)]
        public string Action { set; get; }

        [Display(Name = "操作人")]
        [StringLength(200)]
        public string LoggerUser { set; get; }

        [Display(Name = "参数")]
        [StringLength(200)]
        public string Param { set; get; }

        [Display(Name = "日志内容")]
        [StringLength(6000)]
        public string Message { set; get; }

        [Display(Name = "异常跟踪")]
        [StringLength(2000)]
        public string StackTrace { set; get; }

        [Display(Name = "异常详细")]
        [StringLength(8000)]
        public string Detail { set; get; }
    }
}
