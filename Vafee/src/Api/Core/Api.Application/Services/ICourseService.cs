using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;
using System.Linq.Expressions;

namespace Api.Application.Services;

public interface ICourseService
{
    // todo bool d�nen i�lemlerde, �zel bir d�n�� de�eri kullan�labilir. (Daha fazla bilgi vermesi amac�yla)
    Task<GetCourseDto> GetCourseByIdAsync(string id);
    Task<IEnumerable<GetCourseDto>> GetAllCoursesAsync();
    Task<bool> AddCourseAsync(CreateCourseDto course);
    Task<bool> UpdateCourseAsync(CreateCourseDto course);
    Task<bool> DeleteCourseAsync(string id);
}