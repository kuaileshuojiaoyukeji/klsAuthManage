using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.IService.IUserService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KLS.AuthManage.Component.Tools.Core.Initialize
{
    public class InitData : DropCreateDatabaseIfModelChanges<EFQuestion>
    {
        protected override void Seed(EFQuestion context)
        {
            User user = new User
            {
                UserName = "admin",
                NickName = "管理员",
                PhoneNumber = "00000000000",
                TrueName = "管理员",
                Address = "",
                Enabled = true,
                //初始密码123456 用于数据库初始化系统部署时使用 请使用人员后期进行密码修改
                PasswordHash = "123456",
                CreateTime = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            //默认添加一个管理员角色
            RoleModel role = new RoleModel
            {
                RoleName = "admin",
                OrderSort = 1,
                Description = "超级管理员权限",
                Enabled = true
            };
            var _authService = DependencyResolver.Current.GetService<IAuthService>();
           
            //默认设置admin为admin角色 让其进行权限设置
           var _roleService = DependencyResolver.Current.GetService<IRoleService>();
            _roleService.InsertAsync(role);

            user.Roles.Add(new ApplicationUserRole
            {
                RoleId = 1,
                UserId = 1
            });
            _authService.Register(user);
            //创建系统需要的存储过程
            context.Database.ExecuteSqlCommand(@"CREATE PROCEDURE [dbo].[select_testNames]
                @id int,
                @count int output
            AS
            SELECT Sys_Test.Id, Sys_Test.TestName from Sys_Test where
                 Sys_Test.Id > @id

                set @count = (select COUNT(*) from Sys_Test where Sys_Test.Id > @id)");
            base.Seed(context);
        }
    }
}
