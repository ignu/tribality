using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tribality.Models
{
    public class Message : Entity<int>
    {
        public virtual string Body { get; set; }
        public virtual User From { get; set; }
        public virtual User To { get; set; } 
    }
}
