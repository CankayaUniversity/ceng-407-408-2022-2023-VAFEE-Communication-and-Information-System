using System.Linq.Expressions;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models;

namespace Api.Application.Services;

public interface IDepartmentService
{
    IQueryable<GetDepartmentDto> GetAllDepartments();
    Task<IQueryable<GetDepartmentDto>> GetAllDepartmentsWhereAsync(Expression<Func<Department, bool>> expression);
    Task<GetDepartmentDto> GetDepartmentByIdAsync(string departmentId);

    Task<bool> RemoveDepartmentAsync(string departmentId);
    Task<bool> RemoveDepartmentAsync(Department department);
    Task<bool> RemoveAllDepartmentsWhereAsync(Expression<Func<Department, bool>> expression);

    Task<bool> AddDepartmentAsync(CreateDepartmentDto department);
    Task<bool> AddDepartmentsAsync(IEnumerable<CreateDepartmentDto> departments);
}