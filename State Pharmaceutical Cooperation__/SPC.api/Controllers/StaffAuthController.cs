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
    public class StaffAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StaffAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Register
        [HttpPost("register")]
        public IActionResult Register(StaffDto staffDto)
        {
            if (dbContext.StaffManufacturing.Any(s => s.email == staffDto.email))
            {
                return BadRequest("Email already exists.");
            }

            var staff = new StaffManufacturing
            {
                email = staffDto.email,
                password = staffDto.password // Store the password without hashing
            };

            dbContext.StaffManufacturing.Add(staff);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Login
        [HttpPost("login")]
        public IActionResult Login(StaffDto staffDto)
        {
            var staff = dbContext.StaffManufacturing.FirstOrDefault(s => s.email == staffDto.email && s.password == staffDto.password);

            if (staff == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
