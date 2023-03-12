using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public abstract class BaseMessage
    {
        public string Id { get; set; }
        public string Context { get; set; }
        public string SenderId { get; set; }


        public DateTime SendDate { get; set; }
    }
}
