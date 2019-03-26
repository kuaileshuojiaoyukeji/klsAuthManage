using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.ISysService
{
    public interface ICertificateService
    {
        List<Certificate> SelectAllCertificates();

        Certificate SelectCertificateById(string certificateId);
    }
}
