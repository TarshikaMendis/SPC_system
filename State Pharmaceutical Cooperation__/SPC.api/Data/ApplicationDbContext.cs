using Microsoft.EntityFrameworkCore;
using SPC.api.Models.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SPC.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Define DbSet properties for each table
        public DbSet<Inventory_Details> Inventory_Details { get; set; }
        public DbSet<Tenders> Tenders { get; set; }
        public DbSet<TenderProposal> TenderProposal { get; set; }
        public DbSet<TenderApprovals> TenderApprovals { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<StaffManufacturing> StaffManufacturing { get; set; }
        public DbSet<Pharmacies> Pharmacies { get; set; }
        public DbSet<Orders_Details> Orders_Details { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}
