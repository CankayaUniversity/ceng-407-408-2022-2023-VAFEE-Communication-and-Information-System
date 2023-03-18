using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Course : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public string DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Student> Students { get; set; }
    }
}
