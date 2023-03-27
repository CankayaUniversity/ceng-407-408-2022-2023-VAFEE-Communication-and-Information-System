using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Microsoft.AspNetCore.Identity;
using Api.Domain.Models.Identity;
using MapsterMapper;
using Mapster;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly VafeeContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;

        public StudentsController(VafeeContext context, UserManager<User> userManager,IStudentService studentService)
        {
            
            _context = context;
            _userManager = userManager;
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> GetStudents()
        {
            return await _studentService.GetAllStudentsWithoutImages().ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudent(string id)
        {
            return await _studentService.GetStudentByIdAsync(id);
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(CreateStudentDto studentDto)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'VafeeContext.Students'  is null.");
            }

            var student = new Student()
            {
                Email = studentDto.Email,
                UserName = studentDto.UserName,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Department = new Department()
                {
                    Name = "CENG111"
                }
            };

            var result = await _userManager.CreateAsync(student, studentDto.Password);

            if (result.Succeeded)
            {
                //todo Öğrenciyi uygun role/rollere ekle
            }



            return CreatedAtAction("PostStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(string id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
