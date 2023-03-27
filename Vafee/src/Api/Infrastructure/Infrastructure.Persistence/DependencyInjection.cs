using Api.Application.Services;
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.ServiceImplementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Application.Mapper;
using Mapster;
using MapsterMapper;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {


        private static readonly ConfigurationManager _configurationManager;

        static DependencyInjection()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "WebApi", "WebApi"));
            configurationManager.AddJsonFile("appsettings.json");

            _configurationManager = configurationManager;
        }


        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<VafeeContext>(options =>
            {
                options.UseNpgsql(_configurationManager.GetConnectionString("Postgres"));
            });

            //todo signinmanager?

            services
                .AddIdentityCore<User>(options =>
                {
                    //todo test amacıyla şifrenin zorluğu düşürüldü, uygulama tamamlanınca burayı düzenle
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                    options.User.RequireUniqueEmail = true;

                    // todo eğer kullanıcı adlarında i,ğ gibi türkçe karakter olması gerekiyorsa aşağıda yeni bir string oluşturup
                    // karakterleri ekle.
                    //options.User.AllowedUserNameCharacters = new[] { };


                }).AddUserManager<UserManager<User>>()
                .AddRoles<Role>().AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<VafeeContext>();



            
            services.AddScoped<IStudentService, StudentService>();
            
        }
    }
}
