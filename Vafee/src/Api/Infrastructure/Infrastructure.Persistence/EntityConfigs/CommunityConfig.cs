using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EntityConfigs
{
    public class CommunityConfig : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Community)
                .HasForeignKey(x => x.CommunityId);

            builder
                .HasMany(x => x.Students)
                .WithMany(x => x.Communities);

            builder
                .HasMany(x => x.Instructors)
                .WithMany(x => x.Communities);


        }
    }
}
