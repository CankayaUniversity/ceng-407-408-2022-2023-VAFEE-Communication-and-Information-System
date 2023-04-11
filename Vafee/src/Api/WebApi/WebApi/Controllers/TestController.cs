using Api.Application.Extensions;
using Api.Domain.Models;
using Api.Domain.Models.Identity;
using Bogus;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly VafeeContext _context;

        public TestController(VafeeContext context)
        {
            _context = context;
        }
        
        

        [HttpGet]
        [Route("GenerateRandomRelatedData")]
        public async Task<IActionResult> GenerateRandomRelatedData()
        {
            var testDepartments = new Faker<Department>()
                .RuleFor(d => d.Name, f => f.Name.JobArea()).Generate(17).DistinctBy(x => x.Name);

            var instructorFaker = new Faker<Instructor>()
                .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                .RuleFor(i => i.LastName, f => f.Name.LastName())
                .RuleFor(i=>i.UserName, f=>f.Person.UserName)
                .RuleFor(i => i.Email, f => f.Internet.Email())
                .RuleFor(i => i.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(i => i.Department, f => f.PickRandom<Department>(testDepartments));

            var testInstructors = instructorFaker.Generate(25);

            var testCourses = new Faker<Course>()
                .RuleFor(c => c.Name, f => f.Name.JobArea())
                .RuleFor(c => c.Code, f => f.Commerce.Ean13())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.Instructor, f => f.PickRandom<Instructor>(testInstructors))
                .RuleFor(c => c.Department, f => f.PickRandom<Department>(testDepartments)).Generate(30)
                .DistinctBy(x => x.Name);


            var studentFaker = new Faker<Student>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s=>s.UserName,f=>f.Person.UserName)
                .RuleFor(s => s.Email, f => f.Internet.Email())
                .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(s => s.Department, f => f.PickRandom<Department>(testDepartments))
                .RuleFor(s => s.DepartmentId, (f, s) => s.Department.Id)
                .RuleFor(s => s.Courses, () => testCourses.SelectRandom(5));

            var testStudents = studentFaker.Generate(100);


            var communityFaker = new Faker<Community>()
                .RuleFor(c => c.Name, f => f.Name.JobArea())
                .RuleFor(c => c.Department, f => f.PickRandom<Department>(testDepartments))
                .RuleFor(c => c.Users, () => testStudents.SelectRandom<User>(20));

            var testCommunities = communityFaker.Generate(25).DistinctBy(c => c.Name);


            foreach (var student in testStudents)
            {
                Console.WriteLine(student.FullName);
                Console.WriteLine(student.UserName);
                Console.WriteLine(student.Email);
            }

            await _context.Communities.AddRangeAsync(testCommunities);
            await _context.Students.AddRangeAsync(testStudents);
            await _context.Courses.AddRangeAsync(testCourses);
            await _context.Instructors.AddRangeAsync(testInstructors);
            await _context.Departments.AddRangeAsync(testDepartments);
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
