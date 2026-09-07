using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SuppliersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var suppliers = dbContext.Suppliers.ToList();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var supplier = dbContext.Suppliers.Find(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult AddSupplier(Suppliers supplier)
        {
            dbContext.Suppliers.Add(supplier);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Suppliers supplier)
        {
            var existingSupplier = dbContext.Suppliers.Find(id);
            if (existingSupplier == null) return NotFound();

            existingSupplier.Email = supplier.Email;
            existingSupplier.Password = supplier.Password;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supplier = dbContext.Suppliers.Find(id);
            if (supplier == null) return NotFound();

            dbContext.Suppliers.Remove(supplier);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}