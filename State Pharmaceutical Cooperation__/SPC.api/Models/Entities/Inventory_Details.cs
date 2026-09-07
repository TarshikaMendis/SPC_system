using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models.Entities
{
    public class Inventory_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(100)]
        public required string Drug_Name { get; set; }

        [StringLength(100)]
        public required string Manufacturing_Company { get; set; }

        [StringLength(100)]
        public required string Stock_Quantity { get; set; }

        [StringLength(100)]
        public required string Supplier_Name { get; set; }

        [StringLength(100)]
        public required string Expiry_Date { get; set; }

        [StringLength(100)]
        public required string Unit_Price { get; set; }

        [StringLength(100)]
        public required string Last_Restock_Date { get; set; }

        [StringLength(100)]
        public required string Batch_Number { get; set; }
    }
}
