using Api.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Department : BaseEntity
    {
        public List<Community> Communities { get; set; }
        public List<Course> Courses { get; set; }

        public List<User> Users { get; set; }

        
    }
}
