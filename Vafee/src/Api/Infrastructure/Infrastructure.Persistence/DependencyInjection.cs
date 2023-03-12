using Api.Domain.Models.Identity;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {


        private static readonly ConfigurationManager _configurationManager;

        static DependencyInjection()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Api", "WebApi", "WebApi"));
            configurationManager.AddJsonFile("appsettings.json");

            _configurationManager = configurationManager;
        }


        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<VafeeContext>(options =>
            {
                options.UseNpgsql(_configurationManager.GetConnectionString("Postgres"));
            });

            //todo signinmanager
            services.AddIdentityCore<User>().AddUserManager<UserManager<User>>()
                .AddRoles<Role>().AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<VafeeContext>();



        }
    }
}
