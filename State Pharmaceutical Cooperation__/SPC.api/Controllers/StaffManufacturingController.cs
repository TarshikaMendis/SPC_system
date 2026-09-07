using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffManufacturingController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StaffManufacturingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var staff = dbContext.StaffManufacturing.ToList();
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var staffMember = dbContext.StaffManufacturing.Find(id);
            if (staffMember == null) return NotFound();
            return Ok(staffMember);
        }

        [HttpPost]
        public IActionResult AddStaff(StaffManufacturing staff)
        {
            dbContext.StaffManufacturing.Add(staff);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, StaffManufacturing staff)
        {
            var existingStaff = dbContext.StaffManufacturing.Find(id);
            if (existingStaff == null) return NotFound();

            existingStaff.email = staff.email;
            existingStaff.password = staff.password;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var staff = dbContext.StaffManufacturing.Find(id);
            if (staff == null) return NotFound();

            dbContext.StaffManufacturing.Remove(staff);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}