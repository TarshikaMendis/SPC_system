using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    public partial class Model7 : DbContext
    {
        public Model7()
            : base("name=Model7")
        {
        }

        public virtual DbSet<Tender> Tenders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
