using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;
using System.Linq.Expressions;

namespace Api.Application.Services;

public interface ICourseService
{
    // todo bool dönen iþlemlerde, özel bir dönüþ deðeri kullanýlabilir. (Daha fazla bilgi vermesi amacýyla)
    Task<GetCourseDto> GetCourseByIdAsync(string id);
    Task<IEnumerable<GetCourseDto>> GetAllCoursesAsync();
    Task<bool> AddCourseAsync(CreateCourseDto course);
    Task<bool> UpdateCourseAsync(CreateCourseDto course);
    Task<bool> DeleteCourseAsync(string id);
}