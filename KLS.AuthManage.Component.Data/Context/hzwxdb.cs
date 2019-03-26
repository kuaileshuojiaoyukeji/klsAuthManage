using KLS.AuthManage.Data.Model.Member;
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
        public ApplicationUserStore(hzwxdb context) : base(context) { }
    }

    public class ApplicationRoleStore : RoleStore<Role, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(hzwxdb context) : base(context) { }
    }

    public partial class hzwxdb : IdentityDbContext<User, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationClaim>
    {
        public hzwxdb()
            : base("name=HZDBContext")
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseItem> CourseItem { get; set; }
        public virtual DbSet<CourseItemChapter> CourseItemChapter { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>().ToTable("Sys_User");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("Sys_UserLogin");
            modelBuilder.Entity<ApplicationClaim>().ToTable("Sys_Claim");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("Sys_RoleUser");
            modelBuilder.Entity<Role>().ToTable("Sys_Role");

            modelBuilder.Entity<CourseItem>()
                .Property(e => e.OriginalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CourseItem>()
                .Property(e => e.DiscountPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CourseItem>()
                .Property(e => e.CoursePrice)
                .HasPrecision(19, 4);
        }
    }
}
