using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models.Entities
{
    public partial class Orders_Details
    {
        [Key]
        public int Order_Id { get; set; }

        [Required(ErrorMessage = "Pharmacy Name is required.")]
        [StringLength(255)]
        public string Pharmacy_Name { get; set; }

        [Required(ErrorMessage = "Drug Name is required.")]
        [StringLength(255)]
        public string Drug_Name { get; set; }

        [StringLength(50)]
        public string Batch_Number { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity_Ordered { get; set; }


        public decimal Unit_Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Total_Cost { get; set; } // Computed column from DB

        [DataType(DataType.DateTime)]
        public DateTime Order_Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
