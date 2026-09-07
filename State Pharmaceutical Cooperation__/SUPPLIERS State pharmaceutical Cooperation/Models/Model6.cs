using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    public partial class Model6 : DbContext
    {
        public Model6()
            : base("name=Model6")
        {
        }

        public virtual DbSet<TenderProposal> TenderProposals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenderProposal>()
                .Property(e => e.TotalCost)
                .HasPrecision(29, 2);
        }
    }
}
