using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VafeeContext>
    {
        private readonly ConfigurationManager _configurationManager;

        public DesignTimeDbContextFactory()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Api", "WebApi", "WebApi"));
            configurationManager.AddJsonFile("appsettings.json");

            _configurationManager = configurationManager;
        }

        public VafeeContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<VafeeContext>();
            dbContextOptionsBuilder.UseNpgsql(_configurationManager.GetConnectionString("Postgres"));

            return new VafeeContext(dbContextOptionsBuilder.Options);
        }
    }

}
