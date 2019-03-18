using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.Member
{
    public class RoleModel
    {
        public RoleModel()
        {
            Enabled = true;
            OrderSort = 9999;
        }

        [Display(Name = "角色ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "角色名称不能为空")]
        [Display(Name = "角色名称")]
        [StringLength(20)]
        public string RoleName { get; set; }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "排序号")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是整数")]
        [Range(1, 9999, ErrorMessage = "排序数值范围必须为{1}到{2}")]
        public int OrderSort { get; set; }
    }
}
