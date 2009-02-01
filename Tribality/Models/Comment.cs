using System;

namespace Tribality.Models
{
    public class Comment : Entity<int>
    {
        public virtual string Body { get; set; }
        
        private DateTime date = DateTime.Now;
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public virtual User Poster { get; set; }
        public virtual Post Post { get; set; }
    }
}
