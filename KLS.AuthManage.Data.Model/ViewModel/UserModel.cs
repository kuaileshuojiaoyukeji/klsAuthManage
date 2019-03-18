using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    /// <summary>
    /// 查找用户及登录验证时的vm
    /// </summary>
    public class UserModel
    {
        [Required]

        [Display(Name = "User Name")]

        public string UserName { get; set; }

        [Required]

        [DataType(DataType.Password)]

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]

        public string Password { get; set; }
    }
}
