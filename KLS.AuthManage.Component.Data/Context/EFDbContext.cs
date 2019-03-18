using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.SysModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.Context
{
    public class ApplicationUserStore : UserStore<User, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationClaim>
    {
        public ApplicationUserStore(EFDbContext context): base(context){}
    }

    public class ApplicationRoleStore : RoleStore<Role, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(EFDbContext context): base(context){}
    }

    public class EFDbContext : IdentityDbContext<User, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationClaim>
    {
        public EFDbContext(): base("DefaultContext"){}

        public DbSet<SysTest> SysTest { get; set; }
        public DbSet<SysOnly> SysOnly { get; set; }
        public DbSet<SysLog> SysLog { get; set; }
        public DbSet<SysPermission> SysPermission { get; set; }
        public DbSet<SysModule> SysModule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>().ToTable("Sys_User");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("Sys_UserLogin");
            modelBuilder.Entity<ApplicationClaim>().ToTable("Sys_Claim");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("Sys_RoleUser");
            modelBuilder.Entity<Role>().ToTable("Sys_Role");
        }
    }
}
