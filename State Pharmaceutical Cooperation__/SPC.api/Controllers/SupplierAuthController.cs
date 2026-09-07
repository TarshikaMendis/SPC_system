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
    public class SuppliersAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SuppliersAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Register Supplier
        [HttpPost("register")]
        public IActionResult Register(SuppliersDto suppliersDto)
        {
            // Check if the email already exists
            if (dbContext.Suppliers.Any(s => s.Email == suppliersDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            // Create new supplier object
            var supplier = new Suppliers
            {
                Email = suppliersDto.Email,
                Password = suppliersDto.Password // Store the password without hashing (you should hash it in a real-world app)
            };

            // Add the supplier to the database
            dbContext.Suppliers.Add(supplier);
            dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created); // Return created status
        }

        // Login Supplier
        [HttpPost("login")]
        public IActionResult Login(SuppliersDto suppliersDto)
        {
            // Find supplier by email and password
            var supplier = dbContext.Suppliers
                .FirstOrDefault(s => s.Email == suppliersDto.Email && s.Password == suppliersDto.Password);

            // Check if the supplier exists
            if (supplier == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            // Return a success message with supplier details
            return Ok(new { Message = "Login successful.", SupplierId = supplier.Id, SupplierEmail = supplier.Email });
        }
    }
}
