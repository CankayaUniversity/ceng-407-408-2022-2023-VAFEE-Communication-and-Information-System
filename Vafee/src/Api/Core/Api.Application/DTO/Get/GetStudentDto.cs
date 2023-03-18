using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.DTO.Get
{
    public class GetStudentDto
    {
        public string RollNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Course> Courses { get; set; }
        //public List<Community> Communities { get; set; }
        //public List<Room> Rooms { get; set; }
        //public List<Event> Events { get; set; }
    }
}
