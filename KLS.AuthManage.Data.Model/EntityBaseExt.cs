using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model
{
    /// <summary>
    /// 处理并发-EF数据基类扩展类
    /// </summary>
    [Serializable]
    public abstract class EntityBaseExt
    {
        protected EntityBaseExt(){}

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
