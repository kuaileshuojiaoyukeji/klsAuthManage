namespace KLS.AuthManage.Component.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KLS.AuthManage.Component.Data.Context.EFQuestion>
    {
        public Configuration()
        {
            //Enable-Migrations -Force -ContextTypeName "DbServiceContext" -ProjectName "MVC.Core" -StartUpProjectName "MVC.APP" -ConnectionStringName "DefaultContext" -Verbose
            //Enable-Migrations -EnableAutomaticMigrations 开启迁移
            //Add-Migration InitialCreate                创建迁移版本
            //Update-Database -Verbose                  更新数据库
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "KLS.AuthManage.Component.Data.Context.EFQuestion";
        }

        protected override void Seed(KLS.AuthManage.Component.Data.Context.EFQuestion context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
