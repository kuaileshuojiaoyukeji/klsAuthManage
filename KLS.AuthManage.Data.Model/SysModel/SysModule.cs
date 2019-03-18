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
    [Description("模块")]
    [Table("Sys_Module")]
    public class SysModule : EntityBaseBasics<int>
    {
        public SysModule()
        {
            this.Permissions = new List<SysPermission>();
            this.ChildModules = new List<SysModule>();
        }

        /// <summary>
        /// 获取或设置 添加时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }
        [Description("父模块Id")]
        public int? ParentId { get; set; }
        [Required]
        [Description("名称")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Description("链接地址")]
        [StringLength(500)]
        public string LinkUrl { get; set; }

        [Description("是否是菜单")]
        public bool IsMenu { get; set; }
        [Description("模块编号")]
        public int Code { get; set; }
        [Description("描述")]
        [StringLength(100)]
        public string Description { get; set; }
        [Description("是否激活")]
        public bool Enabled { get; set; }

        public virtual SysModule ParentModule { get; set; }

        public virtual ICollection<SysModule> ChildModules { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<SysPermission> Permissions { get; set; }

        [Description("菜单图标")]
        [StringLength(50)]
        public string ClassIMenu { get; set; }

    }
}
