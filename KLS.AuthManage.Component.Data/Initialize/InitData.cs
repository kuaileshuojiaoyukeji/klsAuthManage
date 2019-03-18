using KLS.AuthManage.Component.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.Initialize
{
    public class InitData : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            //SysUser users = new SysUser { UserName = "admin", PassWord = "admin", UserRealName = "管理员", IsDeleted = false, UpdateDate = DateTime.Now, MobileNumber="13812181456" };
            //context.SysUser.Add(users);
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
