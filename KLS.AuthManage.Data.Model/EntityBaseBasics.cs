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
    /// 简单类-EF数据基类 简单数据表可继承此类
    /// </summary>
    /// <typeparam name="T">主键字段(Id)类型</typeparam>
    [Serializable]
    public abstract class EntityBaseBasics<T>
    {
        protected EntityBaseBasics() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        ///// <summary>
        ///// 获取或设置 添加时间
        ///// </summary>
        //[DataType(DataType.DateTime)]
        //public DateTime CreateDate { get; set; }

        ///// <summary>
        ///// 操作人编号
        ///// </summary>
        //public int OperatorId { get; set; }
    }
}
