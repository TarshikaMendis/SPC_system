using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models.Entities
{
    public partial class Tenders
    {
        [Key]
        public int TenderID { get; set; }

        [Required]
        [StringLength(100)]
        public string DrugName { get; set; }

        public int QuantityRequired { get; set; }

        public string TenderDescription { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime ClosingDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}
