using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model
{
    /// <summary>
    /// EF数据基类
    /// </summary>
    /// <typeparam name="T">主键字段(Id)类型</typeparam>
    [Serializable]
    public abstract class EntityBase<T>
    {
        protected EntityBase()
        {
            UpdateDate = DateTime.Now;
            CreateDate = DateTime.Now;
            IsDeleted = false;
            CreatorID = 0;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        /// <summary>
        ///  获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 获取或设置 添加时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int CreatorID { get; set; }
    }
}
