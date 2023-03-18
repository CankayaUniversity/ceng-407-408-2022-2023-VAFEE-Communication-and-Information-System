using Api.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Room:BaseEntity
    {
        public string Description { get; set; }


        public List<User> Users { get; set; }
        //public List<Student> Students { get; set; }
        //public List<Instructor> Instructors { get; set; }

        //todo mesajlar ve mesaj türleri (nereye gideceğini de çöz)

        public string CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
