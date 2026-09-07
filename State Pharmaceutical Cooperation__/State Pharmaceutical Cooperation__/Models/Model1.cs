using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace State_Pharmaceutical_Cooperation__.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBmodel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove IsFixedLength unless explicitly required
        }
    }
}