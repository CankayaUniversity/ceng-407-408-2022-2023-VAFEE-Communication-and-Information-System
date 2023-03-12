using Api.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Community : BaseEntity
    {
        public List<Room> Rooms { get; set; }
        //public List<User> Users { get; set; }
        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }

        public string DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
