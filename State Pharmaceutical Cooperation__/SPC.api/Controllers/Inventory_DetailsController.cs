using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Inventory_DetailsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Inventory_DetailsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allInventory_Details = dbContext.Inventory_Details.ToList();
            return Ok(allInventory_Details);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inventoryDetails = dbContext.Inventory_Details.Find(id);
            if (inventoryDetails == null) return NotFound();
            return Ok(inventoryDetails);
        }

        [HttpPost]
        public IActionResult AddInventory_Details(AddInventory_Dto addInventory_Details)
        {
            var newInventory_Details = new Inventory_Details
            {
                Drug_Name = addInventory_Details.Drug_Name,
                Manufacturing_Company = addInventory_Details.Manufacturing_Company,
                Stock_Quantity = addInventory_Details.Stock_Quantity,
                Supplier_Name = addInventory_Details.Supplier_Name,
                Expiry_Date = addInventory_Details.Expiry_Date,
                Unit_Price = addInventory_Details.Unit_Price,
                Last_Restock_Date = addInventory_Details.Last_Restock_Date,
                Batch_Number = addInventory_Details.Batch_Number
            };

            dbContext.Inventory_Details.Add(newInventory_Details);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Inventory_Details inventoryDetails)
        {
            var existingInventory = dbContext.Inventory_Details.Find(id);
            if (existingInventory == null) return NotFound();

            existingInventory.Drug_Name = inventoryDetails.Drug_Name;
            existingInventory.Manufacturing_Company = inventoryDetails.Manufacturing_Company;
            existingInventory.Stock_Quantity = inventoryDetails.Stock_Quantity;
            existingInventory.Supplier_Name = inventoryDetails.Supplier_Name;
            existingInventory.Expiry_Date = inventoryDetails.Expiry_Date;
            existingInventory.Unit_Price = inventoryDetails.Unit_Price;
            existingInventory.Last_Restock_Date = inventoryDetails.Last_Restock_Date;
            existingInventory.Batch_Number = inventoryDetails.Batch_Number;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventoryDetails = dbContext.Inventory_Details.Find(id);
            if (inventoryDetails == null) return NotFound();

            dbContext.Inventory_Details.Remove(inventoryDetails);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}