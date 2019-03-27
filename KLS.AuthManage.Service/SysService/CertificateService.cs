using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;

namespace KLS.AuthManage.Service.SysService
{
    public class CertificateService : ICertificateService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        private readonly ISysUserCertificateService _sysUserCertificateService;
        public CertificateService(IDbServiceReposity dbServiceReposity, ISysUserCertificateService sysUserCertificateService)
        {
            _dbServiceReposity = dbServiceReposity;
            _sysUserCertificateService = sysUserCertificateService;
        }

        public List<Certificate> SelectAllCertificates()
        {
            var certIds = _sysUserCertificateService.GetCertificateIdByUserId();
            return _dbServiceReposity.Where<Certificate>(d=> certIds.Contains(d.CertId)).ToList();
        }

        public Certificate SelectCertificateById(string certificateId)
        {
            return _dbServiceReposity.FirstOrDefault<Certificate>(d => d.CertId == certificateId);
        }
    }
}
