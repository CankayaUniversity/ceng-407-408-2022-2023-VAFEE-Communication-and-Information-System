using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.ServiceImplementations;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;

        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> GetCourses()
        {
            var result = await _courseService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result.Data.Adapt<IEnumerable<GetCourseDto>>());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetCourseDto>> GetCourse(string id)
        {
            var result = await _courseService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data.Adapt<GetCourseDto>());
            }

            return NotFound();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromForm] CreateCourseDto courseDto)
        {
            if (id != courseDto.Id)
            {
                return BadRequest();
            }

            var getResult = await _courseService.GetByIdAsync(id);
            var originalRecord = getResult.Data;

            if (originalRecord == null)
            {
                return NotFound();
            }

            courseDto.Adapt(originalRecord);
            var result = await _courseService.UpdateAsync(originalRecord);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Course>> CreateCourse(CreateCourseDto courseDto)
        {
            var record = courseDto.Adapt<Course>();
            var result = await _courseService.AddAsync(record);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var result = await _courseService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}