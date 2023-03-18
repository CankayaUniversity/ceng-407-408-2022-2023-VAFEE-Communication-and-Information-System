using Api.Domain.Models;
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.EntityConfigs;
using Infrastructure.Persistence.EntityConfigs.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class VafeeContext : IdentityDbContext<User, Role, string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {

        public VafeeContext(DbContextOptions<VafeeContext> options) : base(options)
        {

        }


        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Konfigürasyonlar yapıldıktan sonra uygun sırayla ekle.
            // todo bazı NxN ilişkilerde, tablolar üzerinde daha fazla kontrole sahip olmak için veya ekstra column ekleyebilmek için
            // cross table direkt proje içerisinde oluşturulabilir.
            // Örneğin CommunityUser tablosunda, kullanıcının o community'ye kayıt olma tarihini bilebilmek için cross table
            // manuel olarak oluşturulup konfigüre edilmelidir.

            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new BaseEntityConfig());

            builder.ApplyConfiguration(new CommunityConfig());
            builder.ApplyConfiguration(new CourseConfig());
            builder.ApplyConfiguration(new DepartmentConfig());
            builder.ApplyConfiguration(new EventConfig());
            builder.ApplyConfiguration(new RoomConfig());
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new RoleConfig());



        }



        public DbSet<Community> Communities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }

    }


}
