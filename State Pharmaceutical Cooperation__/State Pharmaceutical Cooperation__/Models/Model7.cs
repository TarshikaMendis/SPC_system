using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    public partial class Model7 : DbContext
    {
        public Model7()
            : base("name=dbModel17")
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
