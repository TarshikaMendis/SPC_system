using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=Model4")
        {
        }

        public virtual DbSet<Inventory_Details> Inventory_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Drug_Name)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Manufacturing_Company)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Stock_Quantity)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Supplier_Name)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Expiry_Date)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Unit_Price)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Last_Restock_Date)
                .IsFixedLength();

            modelBuilder.Entity<Inventory_Details>()
                .Property(e => e.Batch_Number)
                .IsFixedLength();
        }
    }
}
