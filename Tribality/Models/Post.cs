using System;

namespace Tribality.Models
{
    public class Post : Entity<int>
    {
        public virtual string Body { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual User Owner { get; set; }        
    }
}
