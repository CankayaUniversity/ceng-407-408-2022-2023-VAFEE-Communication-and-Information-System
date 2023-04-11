using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Get;
using Api.Domain.Models;
using Api.Domain.Models.Identity;
using Mapster;

namespace Api.Application.Mapper
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Student, GetStudentDto>()
                .Map(dto => dto.Email, s => s.Email)
                .Map(dto => dto.UserName, s => s.UserName)
                .Map(dto => dto.FirstName, s => s.FirstName)
                .Map(dto => dto.LastName, s => s.LastName)
                .Map(dto => dto.DepartmentId, s => s.DepartmentId)
                .Map(dto => dto.PhoneNumber, s => s.PhoneNumber)
                .Map(dto => dto.RollNumber, s => s.RollNumber);

            config.NewConfig<Course, GetCourseDto>()
                .Map(dto => dto.Name, c => c.Name)
                .Map(dto => dto.Code, c => c.Code);
        }
    }
}