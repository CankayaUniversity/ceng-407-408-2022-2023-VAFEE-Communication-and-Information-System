using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.Context;
using Api.Application.DTO.Create;
using Api.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // todo bu controller, sadece tüm kullanıcıları listeleme için kullanılabilir.
        // Ya da kullanıcı silme işlemleri de bu controller ile yapılabilir
        // üçüncü olarak bu controller, admin kullanıcıları için userların tüm bilgilerini dönderecek şekilde kullanılabilir
        private readonly VafeeContext _context;

        public UsersController(VafeeContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context.Users.ToListAsync();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent()
        {
            return Ok();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddInstructor")]
        public async Task<IActionResult> AddInstructor()
        {
            return Ok();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }





        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
