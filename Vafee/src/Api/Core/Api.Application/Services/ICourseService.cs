using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;
using System.Linq.Expressions;

namespace Api.Application.Services;

public interface ICourseService
{
    IQueryable<GetCourseDto> GetAllCourses();
    Task<IQueryable<GetCourseDto>> GetAllCoursesWhereAsync(Expression<Func<Course, bool>> expression);
    Task<GetCourseDto> GetCourseByIdAsync(string courseId);

    Task<bool> RemoveCourseAsync(string courseId);
    Task<bool> RemoveCourseAsync(Course course);
    Task<bool> RemoveAllCoursesWhereAsync(Expression<Func<Course, bool>> expression);

    Task<bool> AddCourseAsync(CreateCourseDto course);
    Task<bool> AddCoursesAsync(IEnumerable<CreateCourseDto> courses);

    Task<bool> UpdateCourseAsync(string courseId, CreateCourseDto courseDto);
}