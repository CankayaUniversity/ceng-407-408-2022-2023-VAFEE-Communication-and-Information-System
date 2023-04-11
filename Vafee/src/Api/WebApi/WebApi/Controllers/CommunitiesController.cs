using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly ICommunityService _communityService;

        public CommunitiesController(ICommunityService communityService)
        {
            _communityService = communityService;

        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCommunityDto>>> GetCommunitys()
        {
            var result = await _communityService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result.Data.Adapt<IEnumerable<GetCommunityDto>>());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetCommunityDto>> GetCommunity(string id)
        {
            var result = await _communityService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data.Adapt<GetCommunityDto>());
            }

            return NotFound();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCommunity(string id, [FromForm] CreateCommunityDto communityDto)
        {
            if (id != communityDto.Id)
            {
                return BadRequest();
            }

            var getResult = await _communityService.GetByIdAsync(id);
            var originalRecord = getResult.Data;

            if (originalRecord == null)
            {
                return NotFound();
            }

            communityDto.Adapt(originalRecord);
            var result = await _communityService.UpdateAsync(originalRecord);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Community>> CreateCommunity(CreateCommunityDto communityDto)
        {
            var record = communityDto.Adapt<Community>();
            var result = await _communityService.AddAsync(record);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCommunity(string id)
        {
            var result = await _communityService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
