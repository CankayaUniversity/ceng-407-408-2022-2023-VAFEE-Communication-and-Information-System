using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ServiceImplementations;

public class CourseService : ICourseService
{
    private readonly VafeeContext _context;
    private readonly IMapper _mapper;

    public CourseService(VafeeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<bool> AddCourseAsync(CreateCourseDto course)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCourseAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GetCourseDto>> GetAllCoursesAsync()
    {
        var records = await _context.Courses.ToListAsync();
        return records.Adapt<IEnumerable<GetCourseDto>>();
    }

    public Task<GetCourseDto> GetCourseByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCourseAsync(CreateCourseDto course)
    {
        throw new NotImplementedException();
    }
}