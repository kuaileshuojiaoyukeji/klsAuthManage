namespace KLS.AuthManage.Component.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFhzwxdb : DbContext
    {
        public EFhzwxdb()
            : base("name=EFhzwxdb")
        {
        }

        public virtual DbSet<ScanVideo> ScanVideo { get; set; }
        public virtual DbSet<VideoExam> VideoExam { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
