namespace LoggingTest.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoggingModel : DbContext
    {
        public LoggingModel()
            : base("name=LoggingModel")
        {
        }

        public virtual DbSet<WebLog> WebLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebLog>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<WebLog>()
                .Property(e => e.FormData)
                .IsUnicode(false);

            modelBuilder.Entity<WebLog>()
                .Property(e => e.QueryStringData)
                .IsUnicode(false);

            modelBuilder.Entity<WebLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WebLog>()
                .Property(e => e.IpAddress)
                .IsUnicode(false);
        }
    }
}
