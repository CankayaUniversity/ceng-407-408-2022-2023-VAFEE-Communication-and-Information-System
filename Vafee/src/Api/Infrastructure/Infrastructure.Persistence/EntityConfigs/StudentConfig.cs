using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntityConfigs
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);

            //builder.HasIndex(s => s.RollNumber).IsUnique();
            builder.Property(s => s.RollNumber).HasValueGenerator<StudentNumberGenerator>();
            builder.Property(s => s.Email).HasValueGenerator<StudentEmailGenerator>();
            
            
            
        }
    }

    internal class StudentEmailGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            return "" + "@student.vafee.com";
        }
    }

    internal class StudentNumberGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {

            return "";
        }
    }
}
