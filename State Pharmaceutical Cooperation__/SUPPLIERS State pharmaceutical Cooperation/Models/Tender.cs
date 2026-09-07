namespace SUPPLIERS_State_pharmaceutical_Cooperation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tender
    {
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
