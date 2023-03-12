﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models.Identity
{
    public abstract class User :IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Event> Events { get; set; }
    }
}
