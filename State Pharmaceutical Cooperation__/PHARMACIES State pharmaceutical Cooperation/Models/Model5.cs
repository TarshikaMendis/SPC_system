using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PHARMACIES_State_pharmaceutical_Cooperation.Models
{
    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=Model52")
        {
        }

        public virtual DbSet<Orders_Details> Orders_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders_Details>()
                .Property(e => e.Unit_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders_Details>()
                .Property(e => e.Total_Cost)
                .HasPrecision(21, 2);
        }
    }
}
