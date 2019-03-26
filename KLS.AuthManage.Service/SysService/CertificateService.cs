using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.IService.ISysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.SysService
{
    public class CertificateService : ICertificateService
    {
        private readonly IDbServiceReposity _dbServiceReposity;
        public CertificateService(IDbServiceReposity dbServiceReposity)
        {
            _dbServiceReposity = dbServiceReposity;
        }

        public List<Certificate> SelectAllCertificates()
        {
            return _dbServiceReposity.All<Certificate>().ToList();
        }

        public Certificate SelectCertificateById(string certificateId)
        {
            return _dbServiceReposity.FirstOrDefault<Certificate>(d => d.CertId == certificateId);
        }
    }
}
