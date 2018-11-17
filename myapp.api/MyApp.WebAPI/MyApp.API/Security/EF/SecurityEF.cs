namespace MyApp.API.Security.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SecurityEF : DbContext
    {
        public SecurityEF()
            : base("name=SecurityEF")
        {
        }

        public virtual DbSet<GlobalUser> GlobalUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
