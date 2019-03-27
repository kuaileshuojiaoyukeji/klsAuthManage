using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.IService.ISysService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KLS.AuthManage.Service.SysService
{
    public class SysUserCertificateService : ISysUserCertificateService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public SysUserCertificateService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }
        public List<string> GetCertificateIdByUserId()
        {
            int id = HttpContext.Current.User.Identity.GetUserId<int>();
            return _dbServiceReposity.Where<SysUserCertificate>(d=>d.UserId == id).Select(d => d.CertificateId).ToList();
        }
    }
}
