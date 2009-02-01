using System;
using Iesi.Collections.Generic;

namespace Tribality.Models
{
    public class BlogPost : Post
    {
        public BlogPost()
        {
            Date = DateTime.Now;
        }

        public virtual string Subject { get; set; }
        public virtual ISet<Comment> Comments { get; set; }
        public virtual string PrettyUrl { get; set; }
    }
}
