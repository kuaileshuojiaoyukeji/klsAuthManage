using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.Context
{
    public class ConnectionStringContext
    {
        public readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultContext"].ToString();
    }
}
