using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models.Identity
{
    public abstract class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + LastName;
        public string? Image { get; set; }


        public string IsOnline { get; set; }
        
        public string DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Course>? Courses { get; set; }
        public List<Community>? Communities { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<Event>? Events { get; set; }
    }
}
