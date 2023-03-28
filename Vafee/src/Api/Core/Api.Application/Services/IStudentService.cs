using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;

namespace Api.Application.Services
{
    public interface IStudentService
    {
        // todo Öğrenci ile ilgili olan tüm işlemleri metot olarak ekle
        
        IQueryable<GetStudentDto> GetAllStudents();
        Task<IQueryable<GetStudentDto>> GetAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);
        Task<GetStudentDto> GetStudentByIdAsync(string studentId);

        Task<bool> RemoveStudentAsync(string studentId);
        Task<bool> RemoveStudentAsync(Student student);
        Task<bool> RemoveAllStudentsWhereAsync(Expression<Func<Student, bool>> expression);

        Task<bool> AddStudentAsync(CreateStudentDto student);
        Task<bool> AddStudentsAsync(IEnumerable<CreateStudentDto> students);

    }
}
