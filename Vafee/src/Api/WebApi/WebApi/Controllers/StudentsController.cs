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


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> GetStudents()
        {
            var result = await _studentService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result.Data.Adapt<IEnumerable<GetStudentDto>>());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudent(string id)
        {
            var result = await _studentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data.Adapt<GetStudentDto>());
            }

            return NotFound();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromForm] CreateStudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }

            var getResult = await _studentService.GetByIdAsync(id);
            var originalRecord = getResult.Data;

            if (originalRecord == null)
            {
                return NotFound();
            }

            studentDto.Adapt(originalRecord);
            var result = await _studentService.UpdateAsync(originalRecord);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Student>> CreateStudent(CreateStudentDto studentDto)
        {
            var record = studentDto.Adapt<Student>();
            var result = await _studentService.AddAsync(record);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}