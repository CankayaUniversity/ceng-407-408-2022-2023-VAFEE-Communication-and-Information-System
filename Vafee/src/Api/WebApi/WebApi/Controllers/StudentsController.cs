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
using Api.Application.DTO.Responses;
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
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<GetStudentDto>> GetStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudent(string id)
        {
            return await _studentService.GetStudentByIdAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id,[FromForm] CreateStudentDto studentDto)
        {
            var result = await _studentService.UpdateStudentAsync(id,studentDto);
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(CreateStudentDto studentDto)
        {
            var result = await _studentService.AddStudentAsync(studentDto);
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var result = await _studentService.RemoveStudentAsync(id);
            
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
            
        }

        
    }
}