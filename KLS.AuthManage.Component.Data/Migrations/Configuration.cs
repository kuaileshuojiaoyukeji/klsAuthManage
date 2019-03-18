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
            //��ִ�У�
            //1. CMD->powershell, ����PowerShell ģʽ������ɹ��󣬻�����������߳���PS������
            //2. CMD->Get-ExecutionPolicy, �鿴���ǵ�ǰ�������Ƿ�߱�ִ��PowerShell �����
            //3. CMD->Get-ExecutionPolicy -List �鿴��ǰ���������� 
            // Ok,����������û��Ȩ�ޣ���ô���Ǿ���Ҫȥ��������Ȩ���ˣ�����Ȩ���뿴���Ĳ�
            //4.CMD->Set-ExecutionPolicy RemoteSigned -Scope CurrentUser,���õ�ǰ�û�������߱�Ȩ��
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
