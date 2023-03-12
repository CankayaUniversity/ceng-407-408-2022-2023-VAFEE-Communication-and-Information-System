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
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasMany(r => r.Students);
            builder.HasMany(r => r.Instructors);

            builder
                .HasOne(r => r.Community)
                .WithMany(c => c.Rooms)
                .HasForeignKey(r => r.CommunityId);
        }
    }
}
