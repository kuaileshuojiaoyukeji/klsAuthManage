using KLS.AuthManage.Component.Tools.EnumConfigs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Tools.Helpers
{
    public static class GlobalConfigHelper
    {
        public static int GetSessionTimeOut()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings[EnumGlobalConfig.SessionTimeOut.ToString()].ToString());
        }

        public static string GetVideoUrlRoot()
        {
            return ConfigurationManager.AppSettings[EnumGlobalConfig.VideoUrlRoot.ToString()].ToString();
        }
    }
}
