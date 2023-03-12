using Api.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    //todo event type (exam,meeting) eklenebilir
    public class Event : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
