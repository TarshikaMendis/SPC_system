namespace PHARMACIES_State_pharmaceutical_Cooperation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders_Details
    {
        [Key]
        public int Order_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Pharmacy_Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Drug_Name { get; set; }

       
        public string Batch_Number { get; set; }

        public int Quantity_Ordered { get; set; }

        public decimal Unit_Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Total_Cost { get; set; }

        public DateTime? Order_Date { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
