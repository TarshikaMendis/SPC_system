using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models

{

    using System.Data.Entity;
    public partial class Model2 : DbContext
    {
        public Model2() : base("name=dbModel12") { }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Supplier>()
          //      .Property(e => e.Email)
         //       .IsFixedLength();

       //     modelBuilder.Entity<Supplier>()
        //        .Property(e => e.Password)
          //      .IsFixedLength();
        }
    }
}
