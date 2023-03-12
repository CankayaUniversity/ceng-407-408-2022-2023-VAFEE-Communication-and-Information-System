using Api.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Student:User
    {
        

        public List<Community> Communities { get; set; }
        public List<Course> Courses { get; set; }
    }
}
