using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=Model5")
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
