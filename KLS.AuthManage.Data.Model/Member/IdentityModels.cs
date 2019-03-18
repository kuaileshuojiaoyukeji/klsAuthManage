using KLS.AuthManage.Data.Model.SysModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.Member
{
    public class User : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationClaim>, IUser<int>
    {
        public User()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }

        [Description("真实姓名")]
        [StringLength(20)]
        public string TrueName { get; set; }

        [Description("电话")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Description("地址")]
        [StringLength(300)]
        public string Address { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Description("昵称")]
        [StringLength(50)]
        public string NickName { get; set; }

        [Description("头像")]
        [StringLength(200)]
        public string HeadPortrait { get; set; }

        [Description("性别")]
        [StringLength(1)]
        public string Sex { get; set; }

        [Description("创建时间")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateTime { get; set; }

        [Description("更新时间")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        [Description("审核是否通过")]
        public int? IsReviewed { get; set; }

        [Description("证件号")]
        public string CertificateNo { get; set; }
    }

    public class Role : IdentityRole<int, ApplicationUserRole>
    {
        public Role()
        {
            this.Permissions = new List<SysPermission>();
        }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }
        [Display(Name = "排序")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        [Range(1, 99999)]
        public int OrderSort { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<SysPermission> Permissions { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {

    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {

    }

    public class ApplicationClaim : IdentityUserClaim<int>
    {

    }
}
