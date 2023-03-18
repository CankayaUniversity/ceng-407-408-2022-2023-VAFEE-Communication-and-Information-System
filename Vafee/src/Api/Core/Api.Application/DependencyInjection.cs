using Api.Application.DTO.Get;
using Api.Application.Services;
using Api.Domain.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Api.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            // todo Mapster konfigürasyonunu yap
            //services.AddSingleton(GetConfiguredMappingConfig());
            //services.AddScoped<IMapper, ServiceMapper>();

            // todo uygun projeye server-side validation eklenmeli
            // server-side validationların karşılıkları da client tarafına eklenmeli



            
        }


        private static TypeAdapterConfig GetConfiguredMappingConfig()
        {

            var config = new TypeAdapterConfig
            {

            };




            //config.NewConfig<Student, EnrollmentDto>()
            //    .AfterMappingAsync(async dto =>
            //    {
            //        var context = MapContext.Current.GetService<SchoolContext>();
            //        var course = await context.Courses.FindAsync(dto.CourseID);
            //        if (course != null)
            //            dto.CourseTitle = course.Title;
            //        var student = await context.Students.FindAsync(dto.StudentID);
            //        if (student != null)
            //            dto.StudentName = MapContext.Current.GetService<NameFormatter>().Format(student.FirstMidName, student.LastName);
            //    });
            //config.NewConfig<Student, GetStudentDto>()
            //    .Map(dest => dest.Name, src => MapContext.Current.GetService<NameFormatter>().Format(src.FirstMidName, src.LastName));

            config.NewConfig<Student, GetStudentDto>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.UserName, src => src.UserName);

            return config;
        }
    }
}
