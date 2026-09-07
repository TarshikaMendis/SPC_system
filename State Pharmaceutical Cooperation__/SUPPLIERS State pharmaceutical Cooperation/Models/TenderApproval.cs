namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TenderApproval
    {
        [Key]
        public int ApprovalId { get; set; }

        public int TenderID { get; set; }

        [Required]
        [StringLength(255)]
        public string DrugName { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(255)]
        public string SupplierName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalCost { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
