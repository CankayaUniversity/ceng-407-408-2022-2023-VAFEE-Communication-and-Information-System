using Api.Domain.Models;
using Api.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntityConfigs.Identity
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.UserName);
            
            builder.Property(u => u.Id).HasValueGenerator<UserIdGenerator>();
            builder.Property(u => u.UserName).HasValueGenerator<UserNameGenerator>();
            builder.Property(u => u.Email).HasValueGenerator<UserEmailGenerator>();

            builder.Ignore(u => u.FullName);

            builder
                .HasDiscriminator<string>("UserType")
                .HasValue<Student>("Student")
                .HasValue<Instructor>("Instructor");
        }
    }

    internal class UserEmailGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            throw new NotImplementedException();
        }
    }

    internal class UserNameGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            throw new NotImplementedException();
        }
    }

    //todo Tüm User sınıfındaki kullanıcılar için idler aşağıdaki kurala göre üretiliyor. Aynı işlemi base entity sınıfına da uygula
    internal class UserIdGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {

            // todo Eğer kullanıcının tipini (Student - Instructor) bir şekilde entry üzerinden belirleyebilirsen
            // 2 farklı tür için farklı id kuralları oluşturabilirsin


            // Kullanıcılar için özel id oluşturma kısmı
            var result = entry switch
            {
                
                _ => "BALCIIIII ==>|**|<== " + Guid.NewGuid().ToString()
            };


            return result;

        }
    }
}
