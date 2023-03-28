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

public class DepartmentService : IDepartmentService
{
    private readonly VafeeContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(VafeeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<GetDepartmentDto> GetAllDepartments()
    {
        return _context.Departments.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetDepartmentDto>>();
    }

    public Task<IQueryable<GetDepartmentDto>> GetAllDepartmentsWhereAsync(Expression<Func<Department, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<GetDepartmentDto> GetDepartmentByIdAsync(string departmentId)
    {
        var record = await _context.Departments.FindAsync(departmentId);
        return record?.Adapt<GetDepartmentDto>();
    }

    public Task<bool> RemoveAllDepartmentsWhereAsync(Expression<Func<Department, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddDepartmentAsync(CreateDepartmentDto department)
    {
        var record = department.Adapt<Department>();
        await _context.Departments.AddAsync(record);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddDepartmentsAsync(IEnumerable<CreateDepartmentDto> departments)
    {
        var records = departments.Adapt<IEnumerable<Department>>();
        await _context.Departments.AddRangeAsync(records);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveDepartmentAsync(string departmentId)
    {
        var departmentToDelete = await _context.Departments.FindAsync(departmentId);
        if (departmentToDelete == null)
        {
            return false;
        }

        _context.Departments.Remove(departmentToDelete);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveDepartmentAsync(Department department)
    {
        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync() > 0;
    }
}