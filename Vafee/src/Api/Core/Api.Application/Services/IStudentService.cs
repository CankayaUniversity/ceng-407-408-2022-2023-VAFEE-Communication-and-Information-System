using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Services
{
    public interface IStudentService
    {
        // todo Öğrenci ile ilgili olan tüm işlemleri metot olarak ekle

        IQueryable<Student> GetAllStudentsWithoutImages();
        Task<IQueryable<Student>> GetAllStudentsWithImagesAsync();
        Task<IQueryable<Student>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);

        Task<Student> GetStudentWithoutImageByIdAsync(string studentId);
        Task<Student> GetStudentByIdAsync(string studentId);

        Task<bool> RemoveStudentAsync(string studentId);
        Task<bool> RemoveStudentAsync(Student student);
        Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);


    }
}
