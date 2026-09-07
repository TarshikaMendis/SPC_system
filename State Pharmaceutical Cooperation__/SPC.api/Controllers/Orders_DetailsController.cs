using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders_DetailsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Orders_DetailsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = dbContext.Orders_Details.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = dbContext.Orders_Details.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Orders_Details order)
        {
            dbContext.Orders_Details.Add(order);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Orders_Details order)
        {
            var existingOrder = dbContext.Orders_Details.Find(id);
            if (existingOrder == null) return NotFound();

            existingOrder.Pharmacy_Name = order.Pharmacy_Name;
            existingOrder.Drug_Name = order.Drug_Name;
            existingOrder.Batch_Number = order.Batch_Number;
            existingOrder.Quantity_Ordered = order.Quantity_Ordered;
            existingOrder.Unit_Price = order.Unit_Price;
            existingOrder.Total_Cost = order.Total_Cost;
            existingOrder.Order_Date = order.Order_Date;
            existingOrder.Status = order.Status;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = dbContext.Orders_Details.Find(id);
            if (order == null) return NotFound();

            dbContext.Orders_Details.Remove(order);
            dbContext.SaveChanges();
            return NoContent();
        }



    }
}