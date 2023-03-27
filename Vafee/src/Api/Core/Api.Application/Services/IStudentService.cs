using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Get;

namespace Api.Application.Services
{
    public interface IStudentService
    {
        // todo Öğrenci ile ilgili olan tüm işlemleri metot olarak ekle
        
        IQueryable<GetStudentDto> GetAllStudentsWithoutImages();
        Task<IQueryable<Student>> GetAllStudentsWithImagesAsync();
        Task<IQueryable<Student>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);

        Task<Student> GetStudentWithoutImageByIdAsync(string studentId);
        Task<GetStudentDto> GetStudentByIdAsync(string studentId);

        Task<bool> RemoveStudentAsync(string studentId);
        Task<bool> RemoveStudentAsync(Student student);
        Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);

        Task<bool> AddStudentAsync(Student student);
        Task<bool> AddStudentsAsync(IEnumerable<Student> students);
        Task<bool> AddStudentWithImageAsync(Student student);

    }
}
