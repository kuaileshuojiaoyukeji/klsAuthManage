using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Tools.Core.Initialize
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            LogHelper.LogInfo("3");
            Database.SetInitializer(new InitData());
            using (var db = new EFDbContext())
            {
                LogHelper.LogInfo("4");
                db.Database.Initialize(false);
            }
        }
    }
}
