using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TendersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allTenders = dbContext.Tenders.ToList();
            return Ok(allTenders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tender = dbContext.Tenders.Find(id);
            if (tender == null) return NotFound();
            return Ok(tender);
        }

        [HttpPost]
        public IActionResult AddTender(Tenders tender)
        {
            dbContext.Tenders.Add(tender);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Tenders tender)
        {
            var existingTender = dbContext.Tenders.Find(id);
            if (existingTender == null) return NotFound();

            existingTender.DrugName = tender.DrugName;
            existingTender.QuantityRequired = tender.QuantityRequired;
            existingTender.TenderDescription = tender.TenderDescription;
            existingTender.PublishedDate = tender.PublishedDate;
            existingTender.ClosingDate = tender.ClosingDate;
            existingTender.Status = tender.Status;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tender = dbContext.Tenders.Find(id);
            if (tender == null) return NotFound();

            dbContext.Tenders.Remove(tender);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}