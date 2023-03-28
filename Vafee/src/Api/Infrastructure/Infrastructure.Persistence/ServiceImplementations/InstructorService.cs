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

public class InstructorService:IInstructorService
{
    private readonly VafeeContext _context;
    private readonly IMapper _mapper;

    public InstructorService(VafeeContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public IQueryable<GetInstructorDto> GetAllInstructors()
    {
        return _context.Instructors.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetInstructorDto>>();
    }

    public async Task<IQueryable<GetInstructorDto>> GetAllInstructorsWhereAsync(Expression<Func<Instructor, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<GetInstructorDto> GetInstructorByIdAsync(string studentId)
    {
        var record = await _context.Instructors.FindAsync(studentId);
        return record.Adapt<GetInstructorDto>();
    }

    public async Task<bool> RemoveInstructorAsync(string instructorId)
    {
        var instructorToDelete = await _context.Instructors.FindAsync(instructorId);
        if (instructorToDelete == null)
        {
            return false;
        }
        
        _context.Instructors.Remove(instructorToDelete);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveInstructorAsync(Instructor instructor)
    {
        _context.Instructors.Remove(instructor);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveAllInstructorsWhereAsync(Expression<Func<Instructor, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddInstructorAsync(CreateInstructorDto instructor)
    {
        var record = instructor.Adapt<Instructor>();
        await _context.Instructors.AddAsync(record);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddInstructorsAsync(IEnumerable<CreateInstructorDto> instructors)
    {
        var records = instructors.Adapt<IEnumerable<Instructor>>();
        await _context.Instructors.AddRangeAsync(records);
        return await _context.SaveChangesAsync() > 0;
    }
}