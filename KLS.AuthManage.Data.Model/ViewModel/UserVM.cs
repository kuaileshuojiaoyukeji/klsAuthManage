using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    public class UserVM
    {
        public UserVM()
        {
            Enabled = true;
        }

        [Required(ErrorMessage = "登录名称不能为空")]
        [Display(Name = "登录名称")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "密码")]
        [StringLength(32)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "真实姓名")]
        [StringLength(20)]
        public string TrueName { get; set; }

        [Display(Name = "电子邮件")]
        [Required(ErrorMessage = "电子邮件不能为空")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email地址长度不能超过50个字符")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "电子邮件格式不正确")]
        public string Email { get; set; }

        [Display(Name = "电话")]
        [MaxLength(50, ErrorMessage = "电话长度不能超过50个字符")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        [MaxLength(300, ErrorMessage = "地址长度不能超过300个字符")]
        public string Address { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "证件号")]
        public string CertificateNo { get; set; }
    }
}
