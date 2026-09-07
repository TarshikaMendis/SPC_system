using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PharmaciesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pharmacies = dbContext.Pharmacies.ToList();
            return Ok(pharmacies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pharmacy = dbContext.Pharmacies.Find(id);
            if (pharmacy == null) return NotFound();
            return Ok(pharmacy);
        }

        [HttpPost]
        public IActionResult AddPharmacy(Pharmacies pharmacy)
        {
            dbContext.Pharmacies.Add(pharmacy);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Pharmacies pharmacy)
        {
            var existingPharmacy = dbContext.Pharmacies.Find(id);
            if (existingPharmacy == null) return NotFound();

            existingPharmacy.Email = pharmacy.Email;
            existingPharmacy.Password = pharmacy.Password;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pharmacy = dbContext.Pharmacies.Find(id);
            if (pharmacy == null) return NotFound();

            dbContext.Pharmacies.Remove(pharmacy);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}