using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface ISysUserCertificateService
    {
        /// <summary>
        /// 根据用户id获取对应的科目id
        /// </summary>
        /// <returns></returns>
        List<string> GetCertificateIdByUserId();
    }
}
