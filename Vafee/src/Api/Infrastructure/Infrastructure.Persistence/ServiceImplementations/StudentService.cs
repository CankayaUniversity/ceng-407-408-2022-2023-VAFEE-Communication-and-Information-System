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
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.EntityConfigs;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.ServiceImplementations
{
    public class StudentService : IStudentService
    {
        private readonly VafeeContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public StudentService(VafeeContext context, IMapper mapper,UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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
            var result = await _userManager.CreateAsync(record,student.Password);

            if (result.Succeeded)
            {
                // Rollere ekleme yapılabilir.
            }
            
            return result.Succeeded;
        }

        public async Task<bool> AddStudentsAsync(IEnumerable<CreateStudentDto> students)
        {
            var records = students.Adapt<IEnumerable<Student>>();
            await _context.Students.AddRangeAsync(records);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStudentAsync(string studentId, CreateStudentDto studentDto)
        {
            var studentToUpdate = await _context.Students.FindAsync(studentId);

            if (studentToUpdate == null)
            {
                return false;
            }

            studentToUpdate = studentDto.Adapt(studentToUpdate);
            _context.Students.Update(studentToUpdate);
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