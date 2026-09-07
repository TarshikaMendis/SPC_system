namespace State_Pharmaceutical_Cooperation__.Models
{
    using System.Data.Entity;

    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=dbModel15") // Ensure this matches your connection string name
        {
        }

        public virtual DbSet<Orders_Details> Orders_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders_Details>()
                .Property(e => e.Unit_Price)
                .HasPrecision(10, 2);

            // No need to configure Total_Cost as it's computed in the database
        }
    }
}
