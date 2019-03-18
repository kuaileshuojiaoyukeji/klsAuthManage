using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.ViewModel
{
    public class ModuleModel
    {
        public ModuleModel()
        {
            Enabled = true;
            IsMenu = true;
            LinkUrl = "#";
            Code = 9999;
            ClassIMenu = "fa-windows";
        }
        [Display(Name = "模块ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "模块名称不能为空")]
        [Display(Name = "模块名称")]
        [StringLength(20)]
        public string Name { get; set; }


        [Display(Name = "上级模块ID")]
        public int? ParentId { get; set; }


        [Display(Name = "上级模块")]
        [StringLength(20)]
        public string ParentName { get; set; }

        [Required(ErrorMessage = "链接地址不能为空，不需要链接请设置为“#”号")]
        [Display(Name = "链接地址")]
        [StringLength(500)]
        public string LinkUrl { get; set; }

        [Display(Name = "是否菜单")]
        public bool IsMenu { get; set; }

        [Display(Name = "模块编号")]
        [Range(1, 9999, ErrorMessage = "数值范围必须为{1}到{2}")]
        public int Code { get; set; }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        public string StrIsMenu
        {
            get
            {
                return IsMenu == true ? "是" : "否";
            }
        }

        public string StrEnabled
        {
            get
            {
                return Enabled == true ? "是" : "否";
            }
        }

        [Display(Name = "更新时间")]
        public DateTime UpdateDate { get; set; }

        public string StrUpdateDate
        {
            get
            {
                return UpdateDate.ToString();
            }
        }

        public IList<ModuleModel> ChildModules { get; set; }

        public string ClassIMenu { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string TrueName { get; set; }
    }
}
