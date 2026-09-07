using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    public partial class Model12 : DbContext
    {
        public Model12()
            : base("name=Model12")
        {
        }

        public virtual DbSet<StaffManufacturing> StaffManufacturings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
