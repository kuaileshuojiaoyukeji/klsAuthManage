using KLS.AuthManage.Data.Model.Member;
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
    [Description("角色权限")]
    [Table("Sys_Permission")]
    public class SysPermission : EntityBaseBasics<int>
    {
        public SysPermission()
        {
            this.Roles = new List<Role>();
        }

        /// <summary>
        /// 获取或设置 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }

        [Required]
        [Description("名称")]
        [StringLength(20)]
        public string Name { get; set; }

        [Description("权限编码")]
        public string Code { get; set; }

        [Description("描述")]
        [StringLength(100)]
        public string Description { get; set; }

        public bool Enabled { get; set; }

        [Description("所属模块Id")]
        public int ModuleId { get; set; }

        public virtual SysModule Module { get; set; }

        /// <summary>
        /// 角色集合
        /// </summary>   
        public virtual ICollection<Role> Roles { get; set; }
    }
}
