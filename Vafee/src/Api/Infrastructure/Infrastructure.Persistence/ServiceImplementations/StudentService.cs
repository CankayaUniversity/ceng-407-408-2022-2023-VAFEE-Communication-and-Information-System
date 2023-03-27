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

        public Task<IQueryable<Student>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Student>> GetAllStudentsWithImagesAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<GetStudentDto> GetAllStudentsWithoutImages()
        {
            return _context.Students.Adapt<IQueryable<GetStudentDto>>();
        }

        public async Task<GetStudentDto> GetStudentByIdAsync(string studentId)
        {
            var record = await _context.Students.FindAsync(studentId);
            return record.Adapt<GetStudentDto>();
        }

        public Task<Student> GetStudentWithoutImageByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddStudentsAsync(IEnumerable<Student> students)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddStudentWithImageAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}