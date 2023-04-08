using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;

namespace Infrastructure.Persistence.DataSeed
{
    public static class DbInitializer
    {
        public static async Task PopulateDbContext(this ModelBuilder builder)
        {


            var testDepartments = new Faker<Department>()
                .RuleFor(d => d.Name, f => f.Name.JobArea());

            var testInstructors = new Faker<Instructor>()
                .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                .RuleFor(i => i.LastName, f => f.Name.LastName())
                .RuleFor(i => i.Email, f => f.Internet.Email())
                .RuleFor(i => i.PhoneNumber, f => f.Phone.PhoneNumber());


            var testStudents = new Faker<Student>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Email, f => f.Internet.Email())
                .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber()).Generate(100);


            var testCourses = new Faker<Course>()
                .RuleFor(c => c.Name, f => f.Name.JobArea())
                .RuleFor(c => c.Code, f => f.Commerce.Ean13())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.Instructor, f => f.PickRandom<Instructor>(testInstructors))
                .RuleFor(c=> c.Students, f => f.PickRandom<IEnumerable<Student>>(testStudents));


            

            var testCommunities = new Faker<Community>()
                .RuleFor(c => c.Name, f => f.Name.JobArea());


            builder.Entity<Department>().HasData(testDepartments.Generate(8));
            builder.Entity<Instructor>().HasData(testInstructors.Generate(25));
            builder.Entity<Course>().HasData(testCourses.Generate(50));
            //builder.Entity<Student>().HasData(testStudents.Generate(100));
            builder.Entity<Community>().HasData(testCommunities.Generate(25));




        }
    }
}