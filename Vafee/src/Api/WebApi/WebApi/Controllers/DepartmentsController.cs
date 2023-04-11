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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> GetDepartments()
        {
            var result = await _departmentService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result.Data.Adapt<IEnumerable<GetDepartmentDto>>());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetDepartmentDto>> GetDepartment(string id)
        {
            var result = await _departmentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data.Adapt<GetDepartmentDto>());
            }

            return NotFound();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateDepartment(string id, [FromForm] CreateDepartmentDto departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest();
            }

            var getResult = await _departmentService.GetByIdAsync(id);
            var originalRecord = getResult.Data;

            if (originalRecord == null)
            {
                return NotFound();
            }

            departmentDto.Adapt(originalRecord);
            var result = await _departmentService.UpdateAsync(originalRecord);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var record = departmentDto.Adapt<Department>();
            var result = await _departmentService.AddAsync(record);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            var result = await _departmentService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}