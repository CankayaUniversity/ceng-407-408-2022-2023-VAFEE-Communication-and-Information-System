using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Create;
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
            config.NewConfig<Student, GetStudentDto>();
            config.NewConfig<Student,CreateStudentDto>();
            
            config.NewConfig<Course, GetCourseDto>();
            config.NewConfig<Course, CreateCourseDto>();
            
            config.NewConfig<Department, GetDepartmentDto>();
            config.NewConfig<Department, CreateDepartmentDto>();
            
            config.NewConfig<Community, GetCommunityDto>();
            config.NewConfig<Community, CreateCommunityDto>();
            
            config.NewConfig<Instructor, GetInstructorDto>();
            config.NewConfig<Instructor, CreateInstructorDto>();

        }
    }
}