namespace STAFF___MANUFACTURING_PLANTS_State_Pharmaceutical_Cooperation__.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventory_Details
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Drug_Name { get; set; }

        [StringLength(100)]
        public string Manufacturing_Company { get; set; }

        [StringLength(100)]
        public string Stock_Quantity { get; set; }

        [StringLength(100)]
        public string Supplier_Name { get; set; }

        [StringLength(100)]
        public string Expiry_Date { get; set; }

        [StringLength(100)]
        public string Unit_Price { get; set; }

        [StringLength(100)]
        public string Last_Restock_Date { get; set; }

        [StringLength(100)]
        public string Batch_Number { get; set; }
    }
}
