using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;



namespace PHARMACIES_State_pharmaceutical_Cooperation.Models
{
    public partial class Model4 : DbContext
    {
        public Model4() : base("name=Model4") { }

        public virtual DbSet<Inventory_Details> Inventory_Details { get; set; }
        public virtual DbSet<Orders_Details> Orders_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure entity mappings if needed
           // modelBuilder.Entity<Inventory_Details>()
            //    .Property(e => e.Unit_Price)
               // .HasPrecision(10, 2); // Ensure Unit_Price is treated as a decimal

            modelBuilder.Entity<Orders_Details>()
                .Property(e => e.Unit_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders_Details>()
                .Property(e => e.Total_Cost)
                .HasPrecision(21, 2);
        }
    }
}