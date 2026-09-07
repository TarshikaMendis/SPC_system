using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
