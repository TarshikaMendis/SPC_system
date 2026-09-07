using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models.Entities
{
    public partial class TenderProposal
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(255)]
        public string DrugName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TotalCost { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProposedDeliveryDate { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
