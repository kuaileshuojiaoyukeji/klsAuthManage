using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    public class TestViewModel
    {
        [Required]
        [StringLength(30)]
        [Description("测试名称")]
        public string TestName { get; set; }
    }
}
