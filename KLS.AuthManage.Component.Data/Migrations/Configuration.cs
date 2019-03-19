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
            //Enable-Migrations -Force -ContextTypeName "DbServiceContext" -ProjectName "MVC.Core" -StartUpProjectName "MVC.APP" -ConnectionStringName "DefaultContext" -Verbose
            //Enable-Migrations -EnableAutomaticMigrations ����Ǩ��
            //Add-Migration InitialCreate                ����Ǩ�ư汾
            //Update-Database -Verbose                  �������ݿ�
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
