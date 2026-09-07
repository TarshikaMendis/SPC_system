using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PHARMACIES_State_pharmaceutical_Cooperation.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
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
