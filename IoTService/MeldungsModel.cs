namespace IoTService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MeldungsModel : DbContext
    {
        public MeldungsModel()
            : base("name=MeldungsModel")
        {
        }

        public virtual DbSet<ServiceMeldungen> ServiceMeldungen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceMeldungen>()
                .Property(e => e.Meldung)
                .IsUnicode(false);
        }
    }
}
