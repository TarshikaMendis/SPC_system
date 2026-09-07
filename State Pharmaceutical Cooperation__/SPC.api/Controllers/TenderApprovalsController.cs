using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderApprovalsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TenderApprovalsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var approvals = dbContext.TenderApprovals.ToList();
            return Ok(approvals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var approval = dbContext.TenderApprovals.Find(id);
            if (approval == null) return NotFound();
            return Ok(approval);
        }

        [HttpPost]
        public IActionResult AddApproval(TenderApprovals approval)
        {
            dbContext.TenderApprovals.Add(approval);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, TenderApprovals approval)
        {
            var existingApproval = dbContext.TenderApprovals.Find(id);
            if (existingApproval == null) return NotFound();

            existingApproval.TenderID = approval.TenderID;
            existingApproval.DrugName = approval.DrugName;
            existingApproval.Quantity = approval.Quantity;
            existingApproval.SupplierName = approval.SupplierName;
            existingApproval.UnitPrice = approval.UnitPrice;
            existingApproval.TotalCost = approval.TotalCost;
            existingApproval.DeliveryDate = approval.DeliveryDate;
            existingApproval.Status = approval.Status;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var approval = dbContext.TenderApprovals.Find(id);
            if (approval == null) return NotFound();

            dbContext.TenderApprovals.Remove(approval);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}