using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.Member;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.Initialize
{
    public class InitData : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            User users = new User
            {
                UserName = "admin",
                NickName = "管理员",
                PhoneNumber = "00000000000",
                TrueName = "管理员",
                Address = "",
                Enabled = true,
                //初始密码123456 用于数据库初始化系统部署时使用 请使用人员后期进行密码修改
                PasswordHash = "U2FsdGVkX1/h+7bZlH4SS+f8ZEQs5R5zERTlZ5T+PKc=",
                CreateTime = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            //默认添加一个管理员角色
            Role role = new Role
            {
                Name = "admin",
                OrderSort = 1,
                Description = "超级管理员权限"
            };
            //默认设置admin为admin角色 让其进行权限设置
            context.Users.Add(users);
            context.Roles.Add(role);
            context.SaveChanges();
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
