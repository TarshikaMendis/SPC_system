using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    public partial class Model8 : DbContext
    {
        public Model8()
            : base("name=dbModel18")
        {
        }

        public virtual DbSet<TenderApproval> TenderApprovals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenderApproval>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TenderApproval>()
                .Property(e => e.TotalCost)
                .HasPrecision(12, 2);
        }
    }
}
