namespace SPC.api.Models
{
    public class AddInventory_Dto
    {
        public string Drug_Name { get; set; }
        public string Manufacturing_Company { get; set; }
        public string Stock_Quantity { get; set; }
        public string Supplier_Name { get; set; }
        public string Expiry_Date { get; set; }
        public string Unit_Price { get; set; }
        public string Last_Restock_Date { get; set; }
        public string Batch_Number { get; set; }
    }
}
