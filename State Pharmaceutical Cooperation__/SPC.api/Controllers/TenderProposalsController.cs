using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderProposalsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TenderProposalsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allTenderProposals = dbContext.TenderProposal.ToList();
            return Ok(allTenderProposals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tenderProposal = dbContext.TenderProposal.Find(id);
            if (tenderProposal == null) return NotFound();
            return Ok(tenderProposal);
        }

        [HttpPost]
        public IActionResult AddTenderProposal(TenderProposal tenderProposal)
        {
            dbContext.TenderProposal.Add(tenderProposal);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, TenderProposal tenderProposal)
        {
            var existingTenderProposal = dbContext.TenderProposal.Find(id);
            if (existingTenderProposal == null) return NotFound();

            existingTenderProposal.SupplierName = tenderProposal.SupplierName;
            existingTenderProposal.DrugName = tenderProposal.DrugName;
            existingTenderProposal.Quantity = tenderProposal.Quantity;
            existingTenderProposal.UnitPrice = tenderProposal.UnitPrice;
            existingTenderProposal.TotalCost = tenderProposal.TotalCost;
            existingTenderProposal.ProposedDeliveryDate = tenderProposal.ProposedDeliveryDate;
            existingTenderProposal.Description = tenderProposal.Description;
            existingTenderProposal.Status = tenderProposal.Status;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tenderProposal = dbContext.TenderProposal.Find(id);
            if (tenderProposal == null) return NotFound();

            dbContext.TenderProposal.Remove(tenderProposal);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}