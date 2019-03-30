using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Tools.EnumConfigs
{
    public enum EnumGlobalConfig
    {
        [Description("Session超时")]
        SessionTimeOut,
        [Description("学习视频UrlRoot")]
        VideoUrlRoot,
        [Description("是否启用sql优化 开发人员测试时启用，请发布正式环境时请设置no")]
        SqlListen
    }
}
