using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Mapster;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;

        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetInstructorDto>>> GetInstructors()
        {
            var result = await _instructorService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result.Data.Adapt<IEnumerable<GetInstructorDto>>());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetInstructorDto>> GetInstructor(string id)
        {
            var result = await _instructorService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data.Adapt<GetInstructorDto>());
            }

            return NotFound();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateInstructor(string id, [FromForm] CreateInstructorDto instructorDto)
        {
            if (id != instructorDto.Id)
            {
                return BadRequest();
            }

            var getResult = await _instructorService.GetByIdAsync(id);
            var originalRecord = getResult.Data;

            if (originalRecord == null)
            {
                return NotFound();
            }

            instructorDto.Adapt(originalRecord);
            var result = await _instructorService.UpdateAsync(originalRecord);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Instructor>> CreateInstructor(CreateInstructorDto instructorDto)
        {
            var record = instructorDto.Adapt<Instructor>();
            var result = await _instructorService.AddAsync(record);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteInstructor(string id)
        {
            var result = await _instructorService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
