using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model
{
    /// <summary>
    /// 弃用
    /// </summary>
    [Serializable]
    public abstract class ViewBaseModel
    {
        protected ViewBaseModel()
        {
            CreatorID = -1;
        }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int CreatorID { get; set; }
    }
}
