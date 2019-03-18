namespace KLS.AuthManage.Component.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KLS.AuthManage.Component.Data.Context.EFDbContext>
    {
        public Configuration()
        {
            //先执行：
            //1. CMD->powershell, 进入PowerShell 模式，进入成功后，会在命令行左边出现PS字样；
            //2. CMD->Get-ExecutionPolicy, 查看我们当前作用域是否具备执行PowerShell 的命令；
            //3. CMD->Get-ExecutionPolicy -List 查看当前所有作用域 
            // Ok,所有作用域都没有权限，那么我们就需要去给它设置权限了，设置权限请看第四步
            //4.CMD->Set-ExecutionPolicy RemoteSigned -Scope CurrentUser,设置当前用户作用域具备权限
            //Enable-Migrations -Force -ContextTypeName "DbServiceContext" -ProjectName "MVC.Core" -StartUpProjectName "MVC.APP" -ConnectionStringName "DefaultContext" -Verbose
            //Enable-Migrations -EnableAutomaticMigrations 开启迁移
            //Add-Migration InitialCreate                创建迁移版本
            //Update-Database -Verbose                  更新数据库
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "KLS.AuthManage.Component.Data.Context.EFDbContext";
        }

        protected override void Seed(KLS.AuthManage.Component.Data.Context.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
