using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.api.Data;
using SPC.api.Models.Entities;
using System.Linq;

namespace SPC.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PharmaciesAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(Pharmacies pharmacyDto)
        {
            if (dbContext.Pharmacies.Any(p => p.Email == pharmacyDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var pharmacy = new Pharmacies
            {
                Email = pharmacyDto.Email,
                Password = pharmacyDto.Password // Ideally, hash the password
            };

            dbContext.Pharmacies.Add(pharmacy);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(Pharmacies pharmacyDto)
        {
            var pharmacy = dbContext.Pharmacies.FirstOrDefault(p => p.Email == pharmacyDto.Email && p.Password == pharmacyDto.Password);
            if (pharmacy == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
