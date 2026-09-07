using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=dbModel13")
        {
        }

        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Pharmacy>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
