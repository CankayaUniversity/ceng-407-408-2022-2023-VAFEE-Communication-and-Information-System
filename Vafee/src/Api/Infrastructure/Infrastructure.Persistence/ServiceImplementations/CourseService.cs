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

    public IQueryable<GetCourseDto> GetAllCourses()
    {
        return _context.Courses.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetCourseDto>>();
    }

    public Task<IQueryable<GetCourseDto>> GetAllCoursesWhereAsync(Expression<Func<Course, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<GetCourseDto> GetCourseByIdAsync(string courseId)
    {
        var record = await _context.Courses.FindAsync(courseId);
        return record?.Adapt<GetCourseDto>();
    }

    public Task<bool> RemoveAllCoursesWhereAsync(Expression<Func<Course, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddCourseAsync(CreateCourseDto course)
    {
        var record = course.Adapt<Course>();
        await _context.Courses.AddAsync(record);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddCoursesAsync(IEnumerable<CreateCourseDto> courses)
    {
        var records = courses.Adapt<IEnumerable<Course>>();
        await _context.Courses.AddRangeAsync(records);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveCourseAsync(string courseId)
    {
        var courseToDelete = await _context.Courses.FindAsync(courseId);
        if (courseToDelete == null)
        {
            return false;
        }

        _context.Courses.Remove(courseToDelete);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveCourseAsync(Course course)
    {
        _context.Courses.Remove(course);
        return await _context.SaveChangesAsync() > 0;
    }
}