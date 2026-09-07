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
    public class AdminsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AdminsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var admins = dbContext.Admins.ToList();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = dbContext.Admins.Find(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

       [HttpPost]
public IActionResult AddAdmin(AdminDto adminDto)
{
    var admin = new Admins
    {
        Email = adminDto.Email,
        Password = adminDto.Password
    };

    dbContext.Admins.Add(admin);
    dbContext.SaveChanges();
    return StatusCode(StatusCodes.Status201Created);
}


        [HttpPut("{id}")]
        public IActionResult Edit(int id, AdminDto admin)
        {
            var existingAdmin = dbContext.Admins.Find(id);
            if (existingAdmin == null) return NotFound();

            existingAdmin.Email = admin.Email;
            existingAdmin.Password = admin.Password;

            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var admin = dbContext.Admins.Find(id);
            if (admin == null) return NotFound();

            dbContext.Admins.Remove(admin);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}