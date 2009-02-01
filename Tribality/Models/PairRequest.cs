namespace Tribality.Models
{
    public class PairRequest : Post
    {        
        public virtual string Description { get; set; }
        public virtual Language Language { get; set; }
    }
}
