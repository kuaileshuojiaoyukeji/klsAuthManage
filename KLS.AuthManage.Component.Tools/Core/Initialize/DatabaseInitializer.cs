using KLS.AuthManage.Component.Data.Context;
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
            //Database.SetInitializer(new InitData());
            using (var db = new EFQuestion())
            {
                db.Database.Initialize(false);
            }
            using (var _db = new EFhzwxdb())
            {
                _db.Database.Initialize(false);
            }
        }
    }
}
