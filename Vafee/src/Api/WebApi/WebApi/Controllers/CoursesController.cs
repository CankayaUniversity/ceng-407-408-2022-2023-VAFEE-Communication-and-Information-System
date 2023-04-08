using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.ServiceImplementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<GetCourseDto>> GetCourses()
        {
            return Ok(_courseService.GetAllCourses());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseDto>> GetCourses(string id)
        {
            return await _courseService.GetCourseByIdAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(string id, [FromForm] CreateCourseDto courseDto)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseDto);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CreateCourseDto courseDto)
        {
            var result = await _courseService.AddCourseAsync(courseDto);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var result = await _courseService.RemoveCourseAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
