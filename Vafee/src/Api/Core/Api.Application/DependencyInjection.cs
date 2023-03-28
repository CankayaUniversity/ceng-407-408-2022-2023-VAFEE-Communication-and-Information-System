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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Api.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            // todo Mapster konfigürasyonunu yap (+)
            services.AddMapster();
            

            // todo uygun projeye server-side validation eklenmeli
            // server-side validationların karşılıkları da client tarafına eklenmeli

            


        }


        private static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            
            return services;
        }
    }
}
