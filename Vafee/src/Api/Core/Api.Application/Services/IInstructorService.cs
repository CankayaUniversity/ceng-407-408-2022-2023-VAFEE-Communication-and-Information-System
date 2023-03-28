using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;

namespace Api.Application.Services;

public interface IInstructorService
{
    IQueryable<GetInstructorDto> GetAllInstructors();
    Task<IQueryable<GetInstructorDto>> GetAllInstructorsWhereAsync(Expression<Func<Instructor, bool>> expression);
    Task<GetInstructorDto> GetInstructorByIdAsync(string studentId);

    Task<bool> RemoveInstructorAsync(string instructorId);
    Task<bool> RemoveInstructorAsync(Instructor instructor);
    Task<bool> RemoveAllInstructorsWhereAsync(Expression<Func<Instructor, bool>> expression);

    Task<bool> AddInstructorAsync(CreateInstructorDto instructor);
    Task<bool> AddInstructorsAsync(IEnumerable<CreateInstructorDto> instructors);
}