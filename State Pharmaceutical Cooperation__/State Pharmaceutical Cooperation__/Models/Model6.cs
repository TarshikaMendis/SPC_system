using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    public partial class Model6 : DbContext
    {
        public Model6()
            : base("name=dbModel16")
        {
        }

        public virtual DbSet<Tender> Tenders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
