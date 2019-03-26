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
        public ApplicationUserStore(EFQuestion context) : base(context) { }
    }

    public class ApplicationRoleStore : RoleStore<Role, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(EFQuestion context) : base(context) { }
    }

    public partial class EFQuestion : IdentityDbContext<User, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationClaim>
    {
        public EFQuestion()
            : base("name=EFQuestion")
        {
        }

        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<ChapterSection> ChapterSection { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseQuestionType> CourseQuestionType { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamScheme> ExamScheme { get; set; }
        public virtual DbSet<ExamSchemeScore> ExamSchemeScore { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionOption> QuestionOption { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }

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
