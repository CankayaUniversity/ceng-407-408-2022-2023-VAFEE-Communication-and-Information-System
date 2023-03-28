using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Mapster;
using MapsterMapper;

namespace Infrastructure.Persistence.ServiceImplementations
{
    public class StudentService : IStudentService
    {
        private readonly VafeeContext _context;
        private readonly IMapper _mapper;

        public StudentService(VafeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<GetStudentDto> GetAllStudents()
        {
            return _context.Students.AsNoTrackingWithIdentityResolution().Adapt<IQueryable<GetStudentDto>>();
        }

        public Task<IQueryable<GetStudentDto>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }


        public async Task<GetStudentDto> GetStudentByIdAsync(string studentId)
        {
            var record = await _context.Students.FindAsync(studentId);
            return record?.Adapt<GetStudentDto>();
        }


        public Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddStudentAsync(CreateStudentDto student)
        {
            var record = student.Adapt<Student>();
            await _context.Students.AddAsync(record);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddStudentsAsync(IEnumerable<CreateStudentDto> students)
        {
            var records = students.Adapt<IEnumerable<Student>>();
            await _context.Students.AddRangeAsync(records);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> RemoveStudentAsync(string studentId)
        {
            var studentToDelete = await _context.Students.FindAsync(studentId);

            if (studentToDelete == null)
            {
                return false;
            }

            _context.Students.Remove(studentToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}