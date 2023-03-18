using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntityConfigs
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            

            builder
                .HasMany(x => x.Communities)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId);

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId);

            builder
                .HasMany(d => d.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);
        }
    }

    
}
