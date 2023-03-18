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

namespace Infrastructure.Persistence.ServiceImplementations
{
    public class StudentService : IStudentService
    {
        private readonly VafeeContext _context;

        public StudentService(VafeeContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Student>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Student>> GetAllStudentsWithImagesAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> GetAllStudentsWithoutImages()
        {
            return _context.Students.AsNoTrackingWithIdentityResolution();
        }

        public Task<Student> GetStudentByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentWithoutImageByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression)
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
